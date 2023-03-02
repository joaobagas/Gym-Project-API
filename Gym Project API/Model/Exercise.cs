using System.ComponentModel.DataAnnotations;

namespace Gym_Project_API.Model
{
    public class Exercise
    {
        public string Name { get; set; }
        public List<Set> Sets { get; set; }
    }
}
