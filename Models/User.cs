using System.ComponentModel.DataAnnotations;

namespace chat.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string? Tag { get; set; }
        public string? Password { get; set; }
        public User() { }
        public User(string tag, string password)
        {
            Tag = tag;
            Password = password;
        }
    }
}
