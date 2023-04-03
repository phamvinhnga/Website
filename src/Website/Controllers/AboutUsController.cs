using Microsoft.AspNetCore.Mvc;
using Website.Entity.Repositories.Interfaces;
using Website.Entity;

namespace Website.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IPostRepository _postRepository;

        public AboutUsController(
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
            ViewBag.MetaTitle = p.MetaTitle;
            ViewBag.Permalink = p.Permalink;
            ViewBag.MetaDescription = p.MetaDescription;
            ViewBag.Content = p.Content;
            return View(p);
        }
    }
}
