using System.ComponentModel.DataAnnotations;

namespace Pro401.DTO.AccountDTO
{
    public class UserCredentials
    {
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
        [Required]
        public string Password { get; set; }
    }
}
