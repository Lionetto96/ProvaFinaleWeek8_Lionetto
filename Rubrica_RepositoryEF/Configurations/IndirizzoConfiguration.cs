using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Rubrica_Core.Models;

namespace Rubrica_RepositoryEF
{
    public class IndirizzoConfiguration : IEntityTypeConfiguration<Indirizzo>
    {
        public void Configure(EntityTypeBuilder<Indirizzo> builder)
        {
            builder.ToTable("Indirizzo");
            builder.HasKey(i => i.IndirizzoId);
            builder.Property(i => i.Tipologia).IsRequired().HasMaxLength(20);
            builder.Property(i => i.Via).IsRequired().HasMaxLength(30);
            builder.Property(i => i.Città).IsRequired().HasMaxLength(20);
            builder.Property(i => i.Cap).IsRequired().HasMaxLength(5).IsFixedLength(true);
            builder.Property(i => i.Provincia).IsRequired().HasMaxLength(20);
            builder.Property(i => i.Nazione).IsRequired().HasMaxLength(10);

            //relazione con studenti e lezione
            builder.HasOne(i => i.Contatto).WithMany(i => i.Indirizzi).HasForeignKey(i => i.ContattoId).HasConstraintName("FKContatto");
            
        }
    }
}