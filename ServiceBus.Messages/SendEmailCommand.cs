namespace ServiceBus.Messages
{
    public class SendEmailCommand
    {
        public string Email {get; set;}
        public string Subject {get; set;}
        public string Message {get; set;}
    }
}
