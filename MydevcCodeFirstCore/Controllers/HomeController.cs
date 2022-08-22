using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MydevcCodeFirstCore.Models;
using System.Diagnostics;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace MydevcCodeFirstCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        MydevContext _context;

        public HomeController(ILogger<HomeController> logger, MydevContext context)
        {
            _context = context;
            _logger = logger;
        }

       // static DbContextOptions connectionString = @"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=DevArticle;Integrated Security=True;MultipleActiveResultSets=true;";
       // MydevContext context = new MydevContext(connectionString);
        [HttpGet]
        public IActionResult Index()
        {
            var articles = _context.articles.ToList();
            return View(articles);
        }

        [HttpGet]
        public IActionResult add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add (Articles article)
        {
            _context.articles.Add(article);
            //context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
