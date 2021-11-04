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
using meuyoutube.Controllers.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using meuyoutube.Models.DTO;

namespace meuyoutube.Controllers
{
    [Authorize]
    public class CadastrarController : Controller
    {
        private readonly ILogger<CadastrarController> _logger;
        private readonly IVideoService _videoService;
        private readonly UserManager<Usuario> _userManager;
        private readonly IUsuarioService _usuarioService;
        private readonly IVisibilidadeService _visibilidadeService;
        IWebHostEnvironment _appEnvironment;

        public CadastrarController(ILogger<CadastrarController> logger, IVideoService videoService,
        UserManager<Usuario> userManager, IWebHostEnvironment appEvironment, 
        IUsuarioService usuarioService, IVisibilidadeService visibilidadeService)
        {
            _logger = logger;
            _videoService = videoService;
            _userManager = userManager;
            _appEnvironment = appEvironment;
            _usuarioService = usuarioService;
            _visibilidadeService = visibilidadeService;
        }

        public IActionResult Index()
        {
            CadastrarDTO cdto = new CadastrarDTO();
            cdto.visibilidade = _visibilidadeService.GetAll();
            cdto.playlist = new List<PlayList>();
            return View(cdto);
        }

        public List<Visibilidade> GetVisibilidades()
        {
            List<Visibilidade> lista = _visibilidadeService.GetAll();
            return lista;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(string Titulo, string Descricao, 
        List<IFormFile> Arquivo, string Visibilidade)
        {
            try
            {
                List<Video> video = await UploadFiles.CadastrarVideos(Arquivo, _appEnvironment);
                video[0].Descricao = Descricao;
                video[0].Titulo = Titulo;
                string username = _userManager.GetUserName(User);
                video[0].Usuario = _usuarioService.GetUsuario(username); 
                video[0].Visibilidade = _visibilidadeService.GetById(1);

                bool resp = _videoService.Cadastrar(video[0]);

                return View("Index");                
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return View("Index");
            }
        }
        
    }
}
