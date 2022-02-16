using System.ComponentModel.DataAnnotations;

namespace OperacoesService.Dtos
{
    public class OperacaoCreateDto
    {
        [Required]
        public string ContaNumero { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public decimal Valor { get; set; }
    }
}