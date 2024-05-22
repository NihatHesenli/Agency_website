using BILET_website.DAL;
using BILET_website.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace BILET_website.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class PortfolioController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public PortfolioController(AppDbContext context , IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View(_context.Portfolios.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Portfolio portfolio)
        {
            if(!ModelState.IsValid)
            {

                return View();
            }
            string path = _environment.WebRootPath + @"\Upload\Portfolio\";
            string filename = Guid.NewGuid() + portfolio.ImgFile.FileName;
            using (FileStream stream = new FileStream(path+filename,FileMode.Create))
            {
                portfolio.ImgFile.CopyTo(stream);
            }
            portfolio.ImgUrl = filename;
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Portfolio portfolio= _context.Portfolios.FirstOrDefault(x => x.Id== id);
            if (portfolio == null)
            {

                return RedirectToAction("Index");
            }
           return View(portfolio);
        }
        
    }
}
