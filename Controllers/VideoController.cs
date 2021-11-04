using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using meuyoutube.Models;
using meuyoutube.Services.Interfaces;

namespace meuyoutube.Controllers
{
    public class VideoController : Controller
    {
        private readonly ILogger<VideoController> _logger;
        private readonly IVideoService _videoService;

        public VideoController(ILogger<VideoController> logger, IVideoService videoService)
        {
            _logger = logger;
            _videoService = videoService;
        }

        public IActionResult Index(int id)
        {
            Video video = _videoService.GetVideo(id);
            return View(video);
        }
    }
}
