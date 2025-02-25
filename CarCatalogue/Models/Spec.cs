namespace CarCatalogue.Models
{
    public class Spec
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<CarSpec>? CarSpecs { get; set; }
    }
}
