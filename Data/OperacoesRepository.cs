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

        public Operacao? GetOperacaoById(int id)
        {
            return _context.Operacoes.Find(id);
        }

        public IEnumerable<Operacao> GetOperacoes(DateTime from, DateTime to)
        {
            return _context.Operacoes
                        .Where(e => e.DataHora >= from && e.DataHora <= to)
                        .OrderByDescending(e => e.DataHora)
                        .ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}