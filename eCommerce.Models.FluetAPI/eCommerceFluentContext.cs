using eCommerce.Models.FluetAPI.Configurations;
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
            #region Explicações
            /*
             * Table, Column, NotMapped, DatabaseGenerated(ValueGeneratedNever= None, ValueGeneratedOnAdd=Identity, ValueGeneratedOndAddOrUpdate=Computed)
             * 
             * 
             * 
             * Key*
             * ForeignKey*
             * 
             * Relacionamentos entre tabelas/Entidades;
             * Has/With + One/Many = HasOne, HasMany, WithOne, WithMany
             * 
             * OnDelete*
             * 
             * IsRequired
             * HasMaxLength
             * HasPrecision
             * 
             * 
             */
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIOS");
            modelBuilder.Entity<Usuario>().Property(x => x.RG).HasColumnName("REGISTRO_GERAL").HasMaxLength(10).HasDefaultValue("RG-AUSENTE").IsRequired();
            modelBuilder.Entity<Usuario>().Ignore(x => x.Sexo);
            modelBuilder.Entity<Usuario>().Property(x => x.Id).ValueGeneratedOnAdd();


            modelBuilder.Entity<Usuario>().HasIndex("CPF").IsUnique().HasFilter("[CPF] is not null").HasDatabaseName("IX_CPF_UNIQUE");
            modelBuilder.Entity<Usuario>().HasIndex(x => x.CPF);

            modelBuilder.Entity<Usuario>().HasIndex("CPF", "Email");
            modelBuilder.Entity<Usuario>().HasIndex(x => new { x.CPF, x.Email });

            modelBuilder.Entity<Usuario>().HasKey("Id");
            modelBuilder.Entity<Usuario>().HasKey(x => x.Id);

            modelBuilder.Entity<Usuario>().HasKey("Id", "CPF");
            modelBuilder.Entity<Usuario>().HasKey(x => new {x.Id, x.CPF});

            modelBuilder.Entity<Usuario>().HasAlternateKey("CPF", "Email");

            modelBuilder.Entity<Usuario>().HasNoKey();

            modelBuilder.Entity<Usuario>().HasOne(x => x.Contato).WithOne(x => x.Usuario).HasForeignKey<Contato>(x => x.UsuarioId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Usuario>().HasMany(x => x.EnderecoEntrega).WithOne(x => x.Usuario).HasForeignKey(x => x.Endereco);
            modelBuilder.Entity<Usuario>().HasMany(x => x.Departamentos).WithMany(x => x.Usuarios);

            modelBuilder.Entity<Usuario>().Property(x => x.RG).IsRequired().HasMaxLength(12);
            #endregion

            /*
             * Pequenos/Médio > Cerca 0 - 20 tabelas
             */

            #region Usuario
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Usuario>();
            modelBuilder.Entity<Usuario>();
            #endregion

            #region Contato
            modelBuilder.Entity<Contato>();
            modelBuilder.Entity<Contato>();
            modelBuilder.Entity<Contato>();
            modelBuilder.Entity<Contato>();
            modelBuilder.Entity<Contato>();
            #endregion

            /*
             * Médio/Grande > +10 Tabelas
             */

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        }
    }
}
