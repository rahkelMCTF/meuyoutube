using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meuyoutube.Models
{
    public class VideoDTO
    {
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Visualizacoes { get; set; }
        public string Caminho { get; set; }
        public string Contentype { get; set; }
        public string IdUsuario { get; set; }
        public Visibilidade Visibilidade { get; set; }        
        public int IdPlayList { get; set; }        
    }
}