namespace meistrai_mvc_mano.Models
{
    public class Specialization
    {
        public Specialization()
        {
        }

        public Specialization(string name, ICollection<AutoWorker> autoWorkers)
        {
            Name = name;
            AutoWorkers = autoWorkers;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<AutoWorker> AutoWorkers { get; set; }
     //   public ICollection<AutoService> AutoServices { get; set; }

    }
}
