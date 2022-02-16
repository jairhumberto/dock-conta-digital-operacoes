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
            CreateMap<OperacaoCreateDto, Operacao>()
                    .AfterMap((o,n) => n.DataHora = DateTime.Now);
        }
    }
}