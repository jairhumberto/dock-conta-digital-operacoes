using System.ComponentModel.DataAnnotations;

namespace OperacoesService.Dtos
{
    public class ContaCreateDto
    {
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