using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OperacoesService.Data;
using OperacoesService.Dtos;
using OperacoesService.Models;

namespace OperacoesService.Controllers
{
    [Route("api/os/conta/{contaNumero}/[controller]")]
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

        [HttpPost("saque")]
        public ActionResult<OperacaoReadDto> Saque(string contaNumero, SaqueDto saqueDto)
        {
            var operacaoModel = _mapper.Map<Operacao>(saqueDto);
            operacaoModel.ContaNumero = contaNumero;

            _repository.CreateOperacao(operacaoModel);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetOperacao), new { ContaNumero = contaNumero, Id = operacaoModel.Id }, _mapper.Map<OperacaoReadDto>(operacaoModel));
        }

        [HttpPost("deposito")]
        public ActionResult<OperacaoReadDto> Deposito(string contaNumero, DepositoDto depositoDto)
        {
            var operacaoModel = _mapper.Map<Operacao>(depositoDto);
            operacaoModel.ContaNumero = contaNumero;

            _repository.CreateOperacao(operacaoModel);
            _repository.SaveChanges();

            return CreatedAtRoute(nameof(GetOperacao), new { ContaNumero = contaNumero, Id = operacaoModel.Id }, _mapper.Map<OperacaoReadDto>(operacaoModel));
        }

        [HttpGet("{id}", Name="GetOperacao")]
        public ActionResult<OperacaoReadDto> GetOperacao(string contaNumero, int id)
        {
            var operacaoModel = _repository.GetOperacao(contaNumero, id);

            if (operacaoModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OperacaoReadDto>(operacaoModel));
        }

        [HttpGet]
        public ActionResult<IEnumerable<OperacaoReadDto>> GetOperacoes(string contaNumero, DateTime from, DateTime to)
        {
            var operacoes = _repository.GetOperacoes(contaNumero, from, to);
            return Ok(_mapper.Map<IEnumerable<OperacaoReadDto>>(operacoes));
        }
    }
}