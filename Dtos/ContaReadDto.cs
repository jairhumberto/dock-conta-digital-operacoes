namespace OperacoesService.Dtos
{
    public class ContaReadDto
    {
        public string Numero { get; set; } 
        public decimal Saldo { get; set; }
        public bool Ativa { get; set; }
        public bool Bloqueada { get; set; }
    }
}