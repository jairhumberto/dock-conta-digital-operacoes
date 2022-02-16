using OperacoesService.Models;

namespace OperacoesService.Data
{
    public interface IOperacoesRepository
    {
        void CreateOperacao(Operacao operacao);
        Operacao? GetOperacaoById(int id);
        IEnumerable<Operacao> GetOperacoes();

        void SaveChanges();
    }
}