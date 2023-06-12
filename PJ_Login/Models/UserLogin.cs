using System.ComponentModel.DataAnnotations;

namespace PJ_Login.Models
{
    public class UserLogin
    {
        [Key]
        public int UserId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
