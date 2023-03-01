namespace Gym_Project_API.Model
{
    public class Exercise
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public List<Set> Sets { get; set; }
    }
}
