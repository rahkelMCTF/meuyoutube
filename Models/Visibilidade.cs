using System.ComponentModel.DataAnnotations;

namespace meuyoutube.Models
{
    public class Visibilidade
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
    }
}