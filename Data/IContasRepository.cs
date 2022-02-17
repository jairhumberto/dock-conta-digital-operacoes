using OperacoesService.Models;

namespace OperacoesService.Data
{
    public interface IContasRepository
    {
        void CreateConta(Conta conta);
        Conta? GetContaByNumero(string numero);
        IEnumerable<Conta> GetContas();

        void SaveChanges();
    }
}