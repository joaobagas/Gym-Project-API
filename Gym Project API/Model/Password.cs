namespace Gym_Project_API.Model
{
    public class Password
    {
        public Password(string username, string hashedPassword, string salt)
        {
            Username = username;
            HashedPassword = hashedPassword;
            Salt = salt;
        }

        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public string Salt { get; set; }
    }
}
