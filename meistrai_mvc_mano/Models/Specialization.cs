namespace meistrai_mvc_mano.Models
{
    public class Specialization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AutoWorker> AutoWorkers { get; set; }
     //   public ICollection<AutoService> AutoServices { get; set; }

    }
}
