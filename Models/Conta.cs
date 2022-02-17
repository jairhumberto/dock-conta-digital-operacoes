using System.ComponentModel.DataAnnotations;

namespace OperacoesService.Models
{
    public class Conta
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Numero { get; set; }
    }
}