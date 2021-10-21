using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meuyoutube.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Visualizacoes { get; set; }
        public string Caminho { get; set; }
        public string Contentype { get; set; }
        public DateTime DataUpload { get; set; }
        public Usuario Usuario { get; set; }
        public Visibilidade Visibilidade { get; set; }        
        public List<VideoPlayList> VideoPlayList { get; set; }
        
    }
}