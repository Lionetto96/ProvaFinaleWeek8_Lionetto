using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rubrica_Core.Models;

namespace Rubrica_RepositoryEF
{
    public class ContattoConfiguration : IEntityTypeConfiguration<Contatto>
    {
        public void Configure(EntityTypeBuilder<Contatto> builder)
        {
            builder.ToTable("Contatto");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Cognome).IsRequired().HasMaxLength(20);
           

            //relazione con studenti e lezione
            builder.HasMany(c => c.Indirizzi).WithOne(c => c.Contatto).HasForeignKey(c => c.ContattoId);
        }
    }
}