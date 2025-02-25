using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace CarCatalogue.Models
{
    public class Car
    {
        public int id { get; set; }
        public string Name {get; set;}
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        public List<CarSpec>? CarSpecs { get; set; }
    }
}
