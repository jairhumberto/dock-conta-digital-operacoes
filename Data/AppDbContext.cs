using Microsoft.EntityFrameworkCore;
using OperacoesService.Models;

namespace OperacoesService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        public DbSet<Operacao> Operacoes { get; set; }
        public DbSet<Conta> Contas { get; set; }
    }
}