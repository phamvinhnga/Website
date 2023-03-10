using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Website.Biz.Managers.Interfaces;
using Website.Entity;
using Website.Entity.Repositories.Interfaces;
using Website.Models;

namespace Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IPostRepository _postRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IPostRepository postRepository,
            ApplicationDbContext context
        )
        {
            _logger = logger;
            _context = context;
            _postRepository = postRepository;
        }

        public async Task<IActionResult> Index()
        {
            var p = await _postRepository.GetByIdAsync(1);
            ViewBag.Co = p.Content;
            return View(p);
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