using System;
using System.ComponentModel.DataAnnotations;

namespace meuyoutube.Models
{
    public class Historico
    {
        [Key]
        public int Id { get; set; }
        public DateTime DataFato { get; set; }
        public Usuario Usuario { get; set; }
        public Video Video { get; set; }
    }
}