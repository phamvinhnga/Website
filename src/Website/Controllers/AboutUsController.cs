using Microsoft.AspNetCore.Mvc;
using Website.Entity.Repositories.Interfaces;
using Website.Entity;

namespace Website.Controllers
{
    public class AboutUsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPostRepository _postRepository;

        public AboutUsController(
            ILogger<HomeController> logger,
            IPostRepository postRepository
        )
        {
            _logger = logger;
            _postRepository = postRepository;
        }
        
        [Route("ve-chung-toi")]
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
