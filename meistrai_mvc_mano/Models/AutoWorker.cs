namespace meistrai_mvc_mano.Models
{
    public class AutoWorker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string Nuotrauka { get; set; }
        public AutoService AutoService { get; set; }
        public ICollection<WorkerRating> WorkerRatings { get; set; }
        public ICollection<Specialization> Specializations { get; set; }

    }
}
