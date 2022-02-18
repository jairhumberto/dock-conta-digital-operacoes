using OperacoesService.Models;

namespace OperacoesService.Data
{
    public interface IOperacoesRepository
    {
        void CreateOperacao(Operacao operacao);
        Operacao? GetOperacao(string contaNumero, int id);
        IEnumerable<Operacao> GetOperacoes(string contaNumero, DateTime from, DateTime to);
        decimal QuantidadeSacadoNoDia(string contaNumero);

        void SaveChanges();
    }
}