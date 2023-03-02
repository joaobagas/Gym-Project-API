using System.ComponentModel.DataAnnotations;

namespace Gym_Project_API.Model
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string PostersUsername { get; set; }
        [Timestamp]
        public DateTime DatePosted { get; set; }
        public string Text { get; set; }
        public byte[] Photo { get; set; }
    }
}
