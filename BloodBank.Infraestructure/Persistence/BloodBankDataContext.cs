using BloodBank.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace BloodBank.Infraestructure.Persistence
{
    public class BloodBankDataContext : DbContext    
    {
        public BloodBankDataContext(DbContextOptions<BloodBankDataContext> options)
           : base(options)
        { }

        public DbSet<Doador> Doadores { get; set; }
        public DbSet<Doacao> Doacoes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<EstoqueSangue> EstoquesSangues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Doacao>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasOne(x => x.Doador)
                    .WithMany(d => d.Doacoes)
                    .HasForeignKey(x => x.DoadorId)
                    .OnDelete(DeleteBehavior.Restrict);


                x.Property(x => x.DataDoacao).IsRequired();
                x.Property(x => x.QuantidadeML).IsRequired();
            });

            builder.Entity<Doador>(x =>
            {
                x.HasKey(x => x.Id);

                x.HasMany(x => x.Doacoes)
                    .WithOne(x => x.Doador)
                    .HasForeignKey(x => x.DoadorId)
                    .OnDelete(DeleteBehavior.Restrict);

                
                x.HasOne(x => x.Endereco)
                    .WithOne(e => e.Doador)  
                    .HasForeignKey<Doador>(x => x.EnderecoId)  
                    .OnDelete(DeleteBehavior.Cascade);  
            });

            builder.Entity<Endereco>(x =>
            {
                x.HasKey(x => x.Id);
            });

            builder
                .Entity<EstoqueSangue>(x =>
                {
                    x.HasKey(x => x.Id);

                    x.Property(x => x.TipoSanguineo).IsRequired();
                    x.Property(x => x.FatorRH).IsRequired();
                    x.Property(x => x.QuantidadeML).IsRequired();

                });

            base.OnModelCreating(builder);


        }

    }
}
