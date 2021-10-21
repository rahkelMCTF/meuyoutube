using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace meuyoutube.Models
{
    public class PlayList
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool FlgAtivo { get; set; }        
        public DateTime DataCriacao { get; set; }
        public Usuario Usuario { get; set; }
        public List<VideoPlayList> VideoPlayList { get; set; }
    }
}