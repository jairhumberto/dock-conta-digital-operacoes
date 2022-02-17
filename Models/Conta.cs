using System.ComponentModel.DataAnnotations;

namespace OperacoesService.Models
{
    public class Conta
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string Numero { get; set; }
        
        [Required]
        public decimal Saldo { get; set; }

        [Required]
        public bool Ativa { get; set; }

        [Required]
        public bool Bloqueada { get; set; }
    }
}