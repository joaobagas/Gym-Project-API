using System.ComponentModel.DataAnnotations;

namespace Gym_Project_API.Model
{
    public class User
    {
        public User(string username, string name, DateTime birthday, int height, int weight, DateTime dateRegistered)
        {
            Username = username;
            Name = name;
            Birthday = birthday;
            Height = height;
            Weight = weight;
            DateRegistered = dateRegistered;
        }

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; }
        [Timestamp]
        public DateTime Birthday { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        [Timestamp]
        public DateTime DateRegistered { get; set; }
    }
}
