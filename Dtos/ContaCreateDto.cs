using System.ComponentModel.DataAnnotations;

namespace OperacoesService.Dtos
{
    public class ContaCreateDto
    {
        [Required]
        public string Numero { get; set; }
    }
}