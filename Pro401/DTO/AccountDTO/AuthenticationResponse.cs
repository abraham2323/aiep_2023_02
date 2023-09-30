using System.Data;

namespace Pro401.DTO.AccountDTO
{
    public class AuthenticationResponse
    {
        public string Token { get; set; }
        public DateTime Expiration {  get; set; } 
    }
}
