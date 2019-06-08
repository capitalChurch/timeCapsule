using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Newtonsoft.Json;

namespace TimeCapsule.Model
{
    public class TimeCapsuleApp
    {
        private const string SeparatorString = " - ";
        private static readonly AWSCredentials Credentials = new BasicAWSCredentials(Constants.IdAccessKey, Constants.SecretKey);
        private readonly AmazonS3Client _client = new AmazonS3Client(Credentials, RegionEndpoint.SAEast1);
        private readonly SendEmails _sendEmailApp;

        public TimeCapsuleApp(SendEmails sendEmailApp)
        {
            _sendEmailApp = sendEmailApp;
        }

        public async Task<Message> InsertMessage(Message message)
        {
            message.Id = await GetNextId();
            message.DateRegister = DateTime.UtcNow;
            await SaveMessage(message);
            return message;
        }

        public async Task<List<Message>> SendMessages()
        {
            var list = await ListMessageToSend();

            foreach (var msg in list)
            {
                await _sendEmailApp.SendMessage(msg);
                msg.MessageSent = true;
                await DeleteFile(msg);
                await SaveMessage(msg);
            }
            
            return list;
        }

        private async Task<List<Message>> ListMessageToSend()
        {
            var allFiles = await ListAllKeys();
            var filteredFiles = allFiles.Where(x => x.UnixTimeStampToSend <= GetTimeStamp() && !x.MessageSent).ToList();
            var result = new List<Message>(filteredFiles.Count);

            foreach (var msg in filteredFiles)
            {
                var request = new GetObjectRequest
                {
                    BucketName = Constants.BucketName,
                    Key = GetFileNameByKey(msg)
                };

                using var response = await _client.GetObjectAsync(request);
                using var responseStream = response.ResponseStream;
                using var reader = new StreamReader(responseStream);

                var text = reader.ReadToEnd();
                var obj = JsonConvert.DeserializeObject<Message>(text);
                result.Add(obj);
            }

            return result;
        }

        private async Task<List<KeyMessage>> ListAllKeys()
        {
            var result = new List<List<string>>();
            var request = new ListObjectsV2Request
            {
                BucketName = Constants.BucketName,
                MaxKeys = 10
            };
            ListObjectsV2Response response;
            do
            {
                response = await _client.ListObjectsV2Async(request);
                result.Add(response.S3Objects.Select(x => x.Key).ToList());
                request.ContinuationToken = response.NextContinuationToken;
            } while (response.IsTruncated);
            
            return result
                .SelectMany(x => x)
                .Select(x => x.Replace(".json", ""))
                .Select(x => x.Split(SeparatorString))
                .Select(arr =>
                {
                    var id = Convert.ToInt32(arr[0]);
                    var unixTime = Convert.ToInt64(arr[1]);
                    var sent = Convert.ToBoolean(arr[2]);
                    return new KeyMessage{Id = id, MessageSent = sent, UnixTimeStampToSend = unixTime};
                })
                .ToList();
        }

        private async Task SaveMessage(Message message)
        {
            using var ms = new MemoryStream();

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = ms,
                Key = GetFileName(message),
                BucketName = Constants.BucketName,
                CannedACL = S3CannedACL.Private
            };

            var text = JsonConvert.SerializeObject(message);

            var tw = new StreamWriter(ms);
            tw.Write(text);
            tw.Flush();
            ms.Position = 0;
            
            var utility = new TransferUtility(_client);
            await utility.UploadAsync(uploadRequest);
        }

        private async Task<int> GetNextId()
        {
            var lst = await ListAllKeys();
            if (!lst.Any())
                return 0;
            return lst.Max(x => x.Id) + 1;
        }

        private async Task DeleteFile(Message msg)
        {
            var request = new DeleteObjectRequest
            {
                Key = GetFileName(msg),
                BucketName = Constants.BucketName
            };

            await _client.DeleteObjectAsync(request);
        }

        private long GetTimeStamp(DateTime? time = null)
        {
            var valuedTime = time?.Date ?? DateTime.Now.Date;
            return ((DateTimeOffset)valuedTime).ToUnixTimeSeconds();
        }

        private string GetFileName(Message message)
        {
            message.UnixTimeStampToSend = GetTimeStamp(message.DateRegister.AddYears(message.YearsToSend));
            return GetFileNameByKey(message);
        }

        private string GetFileNameByKey(KeyMessage obj) => 
            $"{obj.Id}{SeparatorString}{obj.UnixTimeStampToSend}{SeparatorString}{obj.MessageSent}.json";

        
    }
}