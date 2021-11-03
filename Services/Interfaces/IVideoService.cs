using System.Collections.Generic;
using meuyoutube.Models;

namespace meuyoutube.Services.Interfaces
{
    public interface IVideoService
    {
        List<Video> GetVideos(int? categoria, string sigla);
        Video GetVideo(int id);
        Video AtualizaViews(int id);
        bool Cadastrar(Video video);
    }
}