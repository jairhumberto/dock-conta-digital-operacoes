using System.ComponentModel.DataAnnotations;

namespace OperacoesService.Models
{
    public class Operacao
    {
        [Key, Required]
        public int Id { get; set; }

        [Required]
        public string ContaNumero { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public decimal Valor { get; set; }

        [Required]
        public DateTime DataHora { get; set; }
    }
}