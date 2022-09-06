namespace meistrai_mvc_mano.Models
{
    public class AutoService
    {
        public AutoService()
        {

        }

        public AutoService(int id)
        {
            Id = id;
        }

        public AutoService(string name, string manager, string address, ICollection<AutoWorker> autoWorkers)
        {
            Name = name;
            Manager = manager;
            Address = address;
            AutoWorkers = autoWorkers;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }
        public string Address { get; set; }
        public ICollection<AutoWorker> AutoWorkers { get; set; }
      //  public Specialization Specialization { get; set; }

    }
}
