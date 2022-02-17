using OperacoesService.Dtos;

namespace OperacoesService.SyncDataServices.Http
{
    public interface IContaDataClient
    {
        Task SendOperacaoToConta(OperacaoReadDto operacao); 
    }
}