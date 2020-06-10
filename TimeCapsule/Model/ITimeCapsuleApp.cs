using System.Collections.Generic;
using System.Threading.Tasks;

namespace TimeCapsule.Model
{
    public interface ITimeCapsuleApp
    {
        Task<Message> InsertMessage(Message message);

        Task<List<Message>> SendMessages();
    }
}