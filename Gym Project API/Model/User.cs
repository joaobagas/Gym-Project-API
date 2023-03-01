namespace Gym_Project_API.Model
{
    public class User
    {
        public User(string username, DateTime birthday, int height, int weight, DateTime dateRegistered)
        {
            Username = username;
            Birthday = birthday;
            Height = height;
            Weight = weight;
            DateRegistered = dateRegistered;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Birthday { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public DateTime DateRegistered { get; set; }
    }
}
