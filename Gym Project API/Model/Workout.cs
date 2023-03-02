using System.ComponentModel.DataAnnotations;

namespace Gym_Project_API.Model
{
    public class Workout
    {
        [Key]
        public string Id { get; set; }
        [Timestamp]
        public DateTime Date { get; set; }
        public List<Exercise> Exercises { get; set; }
    }
}
