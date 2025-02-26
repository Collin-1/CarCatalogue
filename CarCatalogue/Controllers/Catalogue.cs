using CarCatalogue.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarCatalogue.Controllers
{
    public class Catalogue : Controller
    {
        private readonly CarContext _context;
        public Catalogue(CarContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View( await _context.Cars.ToListAsync());
        }
        public async Task<IActionResult> Details (int? id)
        {
            var dish = await _context.Cars
                .Include(di => di.CarSpecs)
                .ThenInclude(i => i.Spec)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }
    }
}
