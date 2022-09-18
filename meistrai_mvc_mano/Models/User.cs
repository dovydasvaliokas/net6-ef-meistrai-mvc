using System.ComponentModel.DataAnnotations.Schema;

namespace meistrai_mvc_mano.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [NotMapped]
        public string RepeatedPassword { get; set; }
        public string Email { get; set; }
        public ICollection<WorkerRating> Ratings { get; set; }

    }
}
