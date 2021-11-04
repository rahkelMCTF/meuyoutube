using meuyoutube.Services.Interfaces;
using meuyoutube.Data;
using System.Collections.Generic;
using meuyoutube.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace meuyoutube.Services {
    public class VideoService : IVideoService
    {
        private readonly ApplicationDbContext _context;

        public VideoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Video> GetVideos(Usuario user)
        {
            try{
                List<Video> Video = new List<Video>();
                
                Video = _context.Video                
                .Where(v => v.Visibilidade.Id == 1 || (v.Visibilidade.Id == 2 && v.Usuario.Id == user.Id) )
                .OrderByDescending(v => v.Visualizacoes)
                .ToList();

                if(Video == null){
                    Video = new List<Video>();
                }

                return Video;
            }
            catch(Exception ex){
                Console.WriteLine(ex);
            }
            return new List<Video>();
        }

        public Video GetVideo(int id)
        {
            Video video = _context.Video
            .Include(v => v.Usuario)
            .SingleOrDefault(v => v.Id == id);
            if(video == null){
                video = new Video();
            }
            return video;
        }

        public Video AtualizaViews(int id)
        {
            Video video = GetVideo(id);
            if(video.Id > 0)
            {
                video.Visualizacoes = video.Visualizacoes + 1;
                _context.Video.Update(video);
                _context.SaveChanges();
            }
            return video;
        }

        public bool Cadastrar(Video video)
        {
           try{
               _context.Video.Add(video);
               _context.SaveChanges();

               return true;
           }
           catch(Exception ex)
           {
               Console.WriteLine(ex);
           }

           return false;
        }
    }
}