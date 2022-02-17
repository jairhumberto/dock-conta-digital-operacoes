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
        private readonly IContasRepository _repository;
        private readonly IMapper _mapper;

        public ContasController(IContasRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<ContaReadDto> CreateConta(ContaCreateDto contaCreateDto)
        {
            var contaModel = _mapper.Map<Conta>(contaCreateDto);

            _repository.CreateConta(contaModel);
            _repository.SaveChanges();

            return Ok(_mapper.Map<ContaReadDto>(contaModel));
        }

        [HttpGet]
        public ActionResult<IEnumerable<ContaReadDto>> GetContas()
        {
            var contas = _repository.GetContas();
            return Ok(_mapper.Map<IEnumerable<ContaReadDto>>(contas));
        }
    }
}