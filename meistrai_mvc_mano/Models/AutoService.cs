namespace meistrai_mvc_mano.Models
{
    public class AutoService
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public string Address { get; set; }
        public ICollection<AutoWorker> AutoWorkers { get; set; }
      //  public Specialization Specialization { get; set; }

    }
}
