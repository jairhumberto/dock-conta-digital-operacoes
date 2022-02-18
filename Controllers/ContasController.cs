using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OperacoesService.Data;
using OperacoesService.Dtos;
using OperacoesService.Models;

namespace OperacoesService.Controllers
{
    [Route("api/os/[controller]")]
    [ApiController]
    public class ContasController : ControllerBase
    {
        private readonly IContasRepository _contasRepository;
        private readonly IMapper _mapper;

        public ContasController(IContasRepository contasRepository, IMapper mapper)
        {
            _contasRepository = contasRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult CreateConta(ContaCreateDto contaCreateDto)
        {
            var contaModel = _contasRepository.GetContaByNumero(contaCreateDto.Numero);

            if (contaModel != null)
            {
                _contasRepository.DeleteConta(contaModel);
            }

            contaModel = _mapper.Map<Conta>(contaCreateDto);

            _contasRepository.CreateConta(contaModel);
            _contasRepository.SaveChanges();

            return NoContent();
        }
    }
}