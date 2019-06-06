using System;
using TimeCapsule.Model;

namespace TimeCapsule.Model
{
    public class Message : KeyMessage
    {
        public string Email { get; set; }
        public DateTime DateRegister { get; set; }
        public int YearsToSend { get; set; }
        public string Text { get; set; }
        public TypeMessageEnum Type { get; set; }
    }
}