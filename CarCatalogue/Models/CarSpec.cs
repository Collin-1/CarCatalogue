namespace CarCatalogue.Models
{
    public class CarSpec
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int SpecId { get; set; }
        public Spec Spec { get; set; }
    }
}
