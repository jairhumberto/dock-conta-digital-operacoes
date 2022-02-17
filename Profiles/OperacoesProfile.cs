using AutoMapper;
using OperacoesService.Dtos;
using OperacoesService.Models;

namespace OperacoesService.Profiles
{
    public class OperacoesProfile : Profile
    {
        public OperacoesProfile()
        {
            CreateMap<Operacao, OperacaoReadDto>();
            
            CreateMap<SaqueDto, Operacao>().AfterMap((o,n) => {
                n.DataHora = DateTime.Now;
                n.Tipo = "saque";
            });

            CreateMap<DepositoDto, Operacao>().AfterMap((o,n) => {
                n.DataHora = DateTime.Now;
                n.Tipo = "deposito";
            });
        }
    }
}