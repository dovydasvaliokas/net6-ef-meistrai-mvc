namespace meistrai_mvc_mano.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public ICollection<WorkerRating> Ratings { get; set; }

    }
}
