namespace meistrai_mvc_mano.Models
{
    public class WorkerRating
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public User User { get; set; }
        public AutoWorker AutoWorker { get; set; }

    }
}
