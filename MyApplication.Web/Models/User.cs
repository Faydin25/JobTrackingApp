using System.ComponentModel.DataAnnotations;

namespace MyApplication.Web.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public int? Password { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
    }
}
