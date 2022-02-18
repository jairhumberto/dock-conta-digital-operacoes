using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OperacoesService.Data;
using OperacoesService.Dtos;
using OperacoesService.Models;
using OperacoesService.SyncDataServices.Http;

namespace OperacoesService.Controllers
{
    [Route("api/os/conta/{contaNumero}/[controller]")]
    [ApiController]
    public class OperacoesController : ControllerBase
    {
        private readonly IOperacoesRepository _operacoesRepository;
        private readonly IContasRepository _contasRepository;
        private readonly IMapper _mapper;
        private readonly IContasServiceClient _contasServiceClient;

        public OperacoesController(IOperacoesRepository operacoesRepository, IContasRepository contasRepository,
                IMapper mapper, IContasServiceClient contasServiceClient)
        {
            _operacoesRepository = operacoesRepository;
            _contasRepository = contasRepository;
            _mapper = mapper;
            _contasServiceClient = contasServiceClient;
        }

        [HttpPost("saque")]
        public async Task<ActionResult<OperacaoReadDto>> Saque(string contaNumero, SaqueDto saqueDto)
        {
            var contaModel = _contasRepository.GetContaByNumero(contaNumero);

            if (contaModel == null)
            {
                return NotFound("Conta nao cadastrada");
            }

            if (!contaModel.Ativa || contaModel.Bloqueada)
            {
                return Unauthorized("Conta inativa ou bloqueada");
            }

            if (saqueDto.Valor <= 0)
            {
                return BadRequest("Valor invalido");
            }

            Console.WriteLine($"Saldo Atual ---> {contaModel.Saldo}");

            if (contaModel.Saldo < saqueDto.Valor)
            {
                return Unauthorized("Saldo insuficiente");
            }

            var operacaoModel = _mapper.Map<Operacao>(saqueDto);
            operacaoModel.ContaNumero = contaNumero;

            var operacaoReadDto = _mapper.Map<OperacaoReadDto>(operacaoModel);
            Console.WriteLine($"Saque ---> {operacaoReadDto.Valor}");
            await _contasServiceClient.ProcessaOperacao(operacaoReadDto);

            _operacoesRepository.CreateOperacao(operacaoModel);
            _operacoesRepository.SaveChanges();

            return CreatedAtRoute(nameof(GetOperacao), new { ContaNumero = contaNumero, Id = operacaoModel.Id },
                    _mapper.Map<OperacaoReadDto>(operacaoModel));
        }

        [HttpPost("deposito")]
        public async Task<ActionResult<OperacaoReadDto>> Deposito(string contaNumero, DepositoDto depositoDto)
        {
            var contaModel = _contasRepository.GetContaByNumero(contaNumero);

            if (contaModel == null)
            {
                return NotFound("Conta nao cadastrada");
            }

            if (!contaModel.Ativa || contaModel.Bloqueada)
            {
                return Unauthorized("Conta inativa ou bloqueada");
            }

            if (depositoDto.Valor <= 0)
            {
                return BadRequest("Valor invalido");
            }

            var operacaoModel = _mapper.Map<Operacao>(depositoDto);
            operacaoModel.ContaNumero = contaNumero;




            var operacaoReadDto = _mapper.Map<OperacaoReadDto>(operacaoModel);
            Console.WriteLine($"Deposito ---> {operacaoReadDto.Valor}");
            await _contasServiceClient.ProcessaOperacao(operacaoReadDto);

            _operacoesRepository.CreateOperacao(operacaoModel);
            _operacoesRepository.SaveChanges();

            return CreatedAtRoute(nameof(GetOperacao), new { ContaNumero = contaNumero, Id = operacaoModel.Id },
                    _mapper.Map<OperacaoReadDto>(operacaoModel));
        }

        [HttpGet("{id}", Name="GetOperacao")]
        public ActionResult<OperacaoReadDto> GetOperacao(string contaNumero, int id)
        {
            if (_contasRepository.GetContaByNumero(contaNumero) == null)
            {
                return NotFound("Conta nao cadastrada");
            }

            var operacaoModel = _operacoesRepository.GetOperacao(contaNumero, id);

            if (operacaoModel == null)
            {
                return NotFound("Operacao nao encontrada");
            }

            return Ok(_mapper.Map<OperacaoReadDto>(operacaoModel));
        }

        [HttpGet]
        public ActionResult<IEnumerable<OperacaoReadDto>> GetOperacoes(string contaNumero, DateTime from, DateTime to)
        {
            if (_contasRepository.GetContaByNumero(contaNumero) == null)
            {
                return NotFound("Conta nao cadastrada");
            }

            var operacoesModels = _operacoesRepository.GetOperacoes(contaNumero, from, to);
            return Ok(_mapper.Map<IEnumerable<OperacaoReadDto>>(operacoesModels));
        }
    }
}