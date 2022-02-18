using OperacoesService.Dtos;

namespace OperacoesService.SyncDataServices.Http
{
    public interface IContasServiceClient
    {
        Task ProcessaOperacao(OperacaoReadDto operacaoReadDto); 
    }
}