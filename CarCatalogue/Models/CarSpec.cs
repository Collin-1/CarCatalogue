namespace CarCatalogue.Models
{
    public class CarSpec
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int SpecID { get; set; }
        public Spec spec { get; set; }
    }
}
