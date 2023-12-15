using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCommerce.Models.FluetAPI
{
    internal class eCommerceFluentContext : DbContext
    {
        /*
         * Conexão sem dinstinção de ambientes de execução
         */

        public eCommerceFluentContext(DbContextOptions<eCommerceFluentContext> options) : base(options)
        {

        }

        public DbSet<Usuario>? Usuarios { get; set; }
        public DbSet<Contato>? Contatos { get; set; }
        public DbSet<EnderecoEntrega>? EnderecosEntrega { get; set; }
        public DbSet<Departamento>? Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             * Table, Column, NotMapped, DatabaseGenerated(ValueGeneratedNever= None, ValueGeneratedOnAdd=Identity, ValueGeneratedOndAddOrUpdate=Computed)
             */
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Usuario>().Property(x => x.RG).HasColumnName("REGISTRO_GERAL").HasMaxLength(10).HasDefaultValue("RG-AUSENTE").IsRequired();
            modelBuilder.Entity<Usuario>().Ignore(x => x.Sexo);
            modelBuilder.Entity<Usuario>().Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}
