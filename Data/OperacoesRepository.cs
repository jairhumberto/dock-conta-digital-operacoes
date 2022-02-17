using OperacoesService.Models;

namespace OperacoesService.Data
{
    public class OperacoesRepository : IOperacoesRepository
    {
        private readonly AppDbContext _context;

        public OperacoesRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateOperacao(Operacao operacao)
        {
            if (operacao == null)
            {
                throw new ArgumentNullException(nameof(operacao));
            }

            _context.Operacoes.Add(operacao);
        }

        public Operacao? GetOperacao(string contaNumero, int id)
        {
            return _context.Operacoes.FirstOrDefault(e => e.ContaNumero == contaNumero && e.Id == id);
        }

        public IEnumerable<Operacao> GetOperacoes(string contaNumero, DateTime from, DateTime to)
        {
            return _context.Operacoes
                        .Where(e => e.ContaNumero == contaNumero && e.DataHora >= from && e.DataHora <= to)
                        .OrderByDescending(e => e.DataHora);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}