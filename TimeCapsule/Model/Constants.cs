using System;
using SendGrid.Helpers.Mail;

namespace TimeCapsule.Model
{
    public static class Constants
    {
        public static string SecretKey => Environment.GetEnvironmentVariable("AWS_ID_KEY");
        public static string IdAccessKey = Environment.GetEnvironmentVariable("AWS_SECRET_KEY");
        public const string BucketName = "timecapsuleemails";
        
        public static string SendGridApiKey = Environment.GetEnvironmentVariable("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");
        private const string FromEmailAddress = "cartaparaofuturo@igrejaCapital.org.br";
        private const string FromEmailName = "Capsula do Tempo";
        private const string EmailAddressResponse = "comunicacao@igrejaCapital.org.br";
        public static EmailAddress FromEmail => new EmailAddress(FromEmailAddress, FromEmailName);
        public static EmailAddress ResponseEmailAddress  => new EmailAddress(EmailAddressResponse);
        
        public static EmailAddress TechnicalResponseEmailAddress => new EmailAddress("kevynsax@gmail.com", "kevyn pinheiro klava");

        public const string SubjectFromThePast = "Sua carta finalmente chegou!";

        public const string SubjectNotification = "Carta para o Futuro";
        public const string TextEmailNotification =
            "Carta para o futuro\n\n Sua carta foi salva com sucesso \n\n Nos vemos daqui um ano\n\nIgreja Batista Capital";
        
        public const string HtmlEmailNotification =
            @"<html><body style=""width: 100%; height: 100%""> <div style=""text-align: center; width: 100%""> <div> <h1 style=""color: #202020; font-size: 40px; line-height: 36px"">PARA O MEU<br/> FUTURO!</h1> </div><div style=""text-align: center; margin: 32px 0;""> <div style=""color: #FF4C01; font-weight: bold; font-size: 24px; line-height: 20px; text-align: center; padding: 8px 0""> Nos vemos<br/>em um ano! </div><div style=""color: #FF4C01; letter-spacing: 3px; padding: 8px;"">CARTA ENVIADA COM SUCESSO!</div></div><div style=""margin: 32px 0;""> <div> <a style=""padding: 0 16px; color: white"" title=""instagram"" href=""https://www.instagram.com/igrejabcapital/""> <img style=""width: 30px"" src=""http://cartaparaofuturo.igrejacapital.org.br.s3-website-sa-east-1.amazonaws.com/img/instagram.fe305588.png"" title=""instagram""> </a> <a style=""padding: 0 16px; color: white"" title=""facebook"" href=""https://www.facebook.com/igrejabcapital/""> <img style=""width: 24px; position: relative; top: -2px"" src=""http://cartaparaofuturo.igrejacapital.org.br.s3-website-sa-east-1.amazonaws.com/img/facebook.3099aff4.png""> </a> <a style=""padding: 0 16px; color: white"" title=""twitter"" href=""https://twitter.com/igrejabcapital""> <img style=""width: 30px"" src=""http://cartaparaofuturo.igrejacapital.org.br.s3-website-sa-east-1.amazonaws.com/img/twitter.3d74e8bf.png""> </a> </div></div><div> <div style=""min-width: 360px; background: #202020; text-align: center""> <a style=""vertical-align: middle"" href=""http://www.igrejacapital.org.br/#/""> <img title=""Igreja Capital"" style=""margin: 40px"" height=""40px"" src=""https://s3-sa-east-1.amazonaws.com/cartaparaofuturo.igrejacapital.org.br/logoIgreja.png"" > </a> </div></div></div></body></html>";

    }
}
