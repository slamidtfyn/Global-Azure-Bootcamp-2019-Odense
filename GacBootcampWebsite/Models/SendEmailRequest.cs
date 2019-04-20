using System.ComponentModel.DataAnnotations;

namespace GacBootcampWebsite.Models
{
    public class SendEmailRequest
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Subject")]
        [DataType(DataType.Text)]
        public string Subject { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Message")]
        [DataType(DataType.Text)]
        public string Message { get; set; }
    }
}
