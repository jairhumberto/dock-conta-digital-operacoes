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

        public void DeleteConta(Conta conta)
        {
            if (conta == null)
            {
                throw new ArgumentNullException(nameof(conta));
            }

            _context.Contas.Remove(conta);
        }

        public Conta? GetContaByNumero(string numero)
        {
            return _context.Contas.FirstOrDefault(e => e.Numero == numero);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}