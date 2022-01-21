using Microsoft.EntityFrameworkCore;
using Rubrica_Core.Models;
using Rubrica_RepositoryEF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryEF
{
    public class Context :DbContext
    {
        //elenco i DbSet 
        public DbSet<Contatto> Contatti { get; set; }
        public DbSet<Indirizzo> Indirizzi { get; set; }
        
        public Context()
        {

        }
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Rubrica;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Contatto>(new ContattoConfiguration());
            modelBuilder.ApplyConfiguration<Indirizzo>(new IndirizzoConfiguration());
            
        }
    }
}
