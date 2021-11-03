using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using meuyoutube.Models;

namespace meuyoutube.Controllers.Util
{
    public static class UploadFiles
    {
        public static async Task<List<Video>> CadastrarVideos(List<IFormFile> Videos, IWebHostEnvironment env)
        {
            try
            {
                IWebHostEnvironment _appEnvironment = env;
                List<Video> Videosadd = new List<Video>();
                int ano = DateTime.Now.Year;
                int mes = DateTime.Now.Month;
                int dia = DateTime.Now.Day;
                if(Videos != null)
                {
                    foreach(var doc in Videos){
                        var caminhoVideo = Path.GetTempFileName();
                        string caminho_WebRoot = _appEnvironment.ContentRootPath + "\\assets\\uploads\\";
                        string nomealeatorio = Path.GetRandomFileName();
                        string caminhoDestinoVideo = caminho_WebRoot + ano + "\\" + mes + "\\" + dia + "\\" + nomealeatorio;
                        string caminhorelativo = "\\assets\\uploads\\" + ano + "\\" + mes + "\\" + dia + "\\" + nomealeatorio;
                        
                        if (!Directory.Exists(caminhoDestinoVideo))
                        {
                            DirectoryInfo di = Directory.CreateDirectory(caminhoDestinoVideo);
                        }

                        using (var stream = new FileStream(Path.Combine(caminhoDestinoVideo, doc.FileName), FileMode.Create))
                        {
                            await doc.CopyToAsync(stream);                             
                            Video item = new Video();
                            item.Nome = doc.FileName;
                            item.Contentype = doc.ContentType;
                            item.Caminho = caminhorelativo;
                            Videosadd.Add(item);
                        }                        
                    }
                }
                return Videosadd;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                return new List<Video>();
            }
        }

    }
}