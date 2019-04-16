namespace GacBootcampWebsite.Models
{
    public class DefaultFormResponse
    {
        public bool Success { get; }
        public string Message { get; }

        private DefaultFormResponse(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public static DefaultFormResponse Create(bool success, string message)
        {
            return new DefaultFormResponse(success, message);
        }
    }
}
