using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Website.Entity;
using Website.Entity.Repositories.Interfaces;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IPostRepository postRepository,
            ApplicationDbContext context
        )
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public async Task<IActionResult> Index()
        {
            var p = await _postRepository.GetByIdAsync(1);
            ViewBag.MetaTitle = p.MetaTitle;
            ViewBag.Permalink = p.Permalink;
            ViewBag.MetaDescription = p.MetaDescription;
            ViewBag.Content = p.Content;
            return View(p);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}