namespace OperacoesService.Models
{
    public class Operacao
    {
        public int Id { get; set; }
        public string ContaNumero { get; set; }
        public string Tipo { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataHora { get; set; }
    }
}