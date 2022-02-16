using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OperacoesService.Data;
using OperacoesService.Dtos;
using OperacoesService.Models;

namespace OperacoesService.Controllers
{
    [Route("api/os/[controller]")]
    [ApiController]
    public class OperacoesController : ControllerBase
    {
        private readonly IOperacoesRepository _repository;
        private readonly IMapper _mapper;

        public OperacoesController(IOperacoesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<OperacaoReadDto> CreateOperacao(OperacaoCreateDto operacaoCreateDto)
        {
            var operacao = _mapper.Map<Operacao>(operacaoCreateDto);

            _repository.CreateOperacao(operacao);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetOperacaoById), new { Id = operacao.Id }, _mapper.Map<OperacaoReadDto>(operacao));
        }

        [HttpGet("{id}", Name="GetOperacaoById")]
        public ActionResult<OperacaoReadDto> GetOperacaoById(int id)
        {
            var operacao = _repository.GetOperacaoById(id);

            if (operacao != null)
            {
                return Ok(_mapper.Map<OperacaoReadDto>(operacao));
            }

            return NotFound();
        }

        [HttpGet]
        public ActionResult<IEnumerable<OperacaoReadDto>> GetOperacoes(DateTime from, DateTime to)
        {
            var operacoes = _repository.GetOperacoes(from, to);
            return Ok(_mapper.Map<IEnumerable<OperacaoReadDto>>(operacoes));
        }
    }
}