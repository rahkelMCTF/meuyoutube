using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using meuyoutube.Models;
using meuyoutube.Services.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace meuyoutube.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVideoService _videoService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IUsuarioService _usuarioService;


        public HomeController(ILogger<HomeController> logger, IVideoService videoService,
        UserManager<Usuario> userManager, IUsuarioService usuarioService)
        {
            _logger = logger;
            _videoService = videoService;
            _userManager = userManager;
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            string username = _userManager.GetUserName(User);
            Usuario user = _usuarioService.GetUsuario(username);
            List<Video> lista = _videoService.GetVideos(user);
            return View(lista);
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
