using OperacoesService.Models;

namespace OperacoesService.Data
{
    public class ContasRepository : IContasRepository
    {
        private readonly AppDbContext _context;

        public ContasRepository(AppDbContext context)
        {
            _context = context;
        }

        public void CreateConta(Conta conta)
        {
            if (conta == null)
            {
                throw new ArgumentNullException(nameof(conta));
            }

            _context.Contas.Add(conta);
        }

        public Conta? GetContaByNumero(string numero)
        {
            return _context.Contas.FirstOrDefault(e => e.Numero == numero);
        }

        public IEnumerable<Conta> GetContas()
        {
            return _context.Contas;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}