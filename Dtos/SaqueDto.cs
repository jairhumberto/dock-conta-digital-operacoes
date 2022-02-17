using System.ComponentModel.DataAnnotations;

namespace OperacoesService.Dtos
{
    public class SaqueDto
    {
        [Required]
        public decimal Valor { get; set; }
    }
}