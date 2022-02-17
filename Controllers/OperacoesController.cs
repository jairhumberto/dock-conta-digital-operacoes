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
        private readonly IOperacoesRepository _operacoesRepository;
        private readonly IContasRepository _contasRepository;
        private readonly IMapper _mapper;

        public OperacoesController(IOperacoesRepository operacoesRepository, IContasRepository contasRepository, IMapper mapper)
        {
            _operacoesRepository = operacoesRepository;
            _contasRepository = contasRepository;
            _mapper = mapper;
        }

        [HttpPost("saque")]
        public ActionResult<OperacaoReadDto> Saque(string contaNumero, SaqueDto saqueDto)
        {
            if (_contasRepository.GetContaByNumero(contaNumero) == null)
            {
                return NotFound("Conta não encontrada");
            }

            var operacaoModel = _mapper.Map<Operacao>(saqueDto);
            operacaoModel.ContaNumero = contaNumero;

            _operacoesRepository.CreateOperacao(operacaoModel);
            _operacoesRepository.SaveChanges();

            return CreatedAtRoute(nameof(GetOperacao), new { ContaNumero = contaNumero, Id = operacaoModel.Id }, _mapper.Map<OperacaoReadDto>(operacaoModel));
        }

        [HttpPost("deposito")]
        public ActionResult<OperacaoReadDto> Deposito(string contaNumero, DepositoDto depositoDto)
        {
            if (_contasRepository.GetContaByNumero(contaNumero) == null)
            {
                return NotFound("Conta não encontrada");
            }

            var operacaoModel = _mapper.Map<Operacao>(depositoDto);
            operacaoModel.ContaNumero = contaNumero;

            _operacoesRepository.CreateOperacao(operacaoModel);
            _operacoesRepository.SaveChanges();

            return CreatedAtRoute(nameof(GetOperacao), new { ContaNumero = contaNumero, Id = operacaoModel.Id }, _mapper.Map<OperacaoReadDto>(operacaoModel));
        }

        [HttpGet("{id}", Name="GetOperacao")]
        public ActionResult<OperacaoReadDto> GetOperacao(string contaNumero, int id)
        {
            if (_contasRepository.GetContaByNumero(contaNumero) == null)
            {
                return NotFound("Conta não encontrada");
            }

            var operacaoModel = _operacoesRepository.GetOperacao(contaNumero, id);
            if (operacaoModel == null)
            {
                return NotFound("Operacao não encontrada");
            }

            return Ok(_mapper.Map<OperacaoReadDto>(operacaoModel));
        }

        [HttpGet]
        public ActionResult<IEnumerable<OperacaoReadDto>> GetOperacoes(string contaNumero, DateTime from, DateTime to)
        {
            if (_contasRepository.GetContaByNumero(contaNumero) == null)
            {
                return NotFound("Conta não encontrada");
            }

            var operacoes = _operacoesRepository.GetOperacoes(contaNumero, from, to);
            return Ok(_mapper.Map<IEnumerable<OperacaoReadDto>>(operacoes));
        }
    }
}