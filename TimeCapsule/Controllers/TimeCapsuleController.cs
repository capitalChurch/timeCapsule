using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TimeCapsule.Model;

namespace TimeCapsule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeCapsuleController : ControllerBase
    {
        private readonly TimeCapsuleApp _app;

        public TimeCapsuleController(TimeCapsuleApp app)
        {
            _app = app;
        }

        [HttpPost]
        public Task<Message> InsertMessage([FromBody] Message obj) => _app.InsertMessage(obj);

        [HttpPost("SendMessages")]
        public Task<List<Message>> GetAllMessages() => _app.SendMessages();
    }
}