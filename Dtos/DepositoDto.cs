using System.ComponentModel.DataAnnotations;

namespace OperacoesService.Dtos
{
    public class DepositoDto
    {
        [Required]
        public decimal Valor { get; set; }
    }
}