using Microsoft.EntityFrameworkCore;

namespace StatusCode.Models
{
    public class SistemaContext: DbContext
    {
        public DbSet<Usuario>? Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder Modelagem)
        {
            Modelagem.Entity<Usuario>(Tabela =>
            {
                Tabela.HasKey(Propriedade => Propriedade.Id);
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder Config)
        {
            Config.UseInMemoryDatabase("Sistema");
        }
    }
}
