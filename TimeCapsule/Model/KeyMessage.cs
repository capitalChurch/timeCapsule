namespace TimeCapsule.Model
{
    public class KeyMessage
    {
        
        public int Id { get; set; }
        public long UnixTimeStampToSend { get; set; }
        public bool MessageSent { get; set; }
    }
}