using AutoMapper;
using OperacoesService.Dtos;
using OperacoesService.Models;

namespace OperacoesService.Profiles
{
    public class ContasProfile : Profile
    {
        public ContasProfile()
        {
            CreateMap<Conta, ContaReadDto>();
            CreateMap<ContaCreateDto, Conta>();
        }
    }
}