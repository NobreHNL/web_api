using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class WebApiContext : DbContext
    {
        public WebApiContext() : base("name=WebApiContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Animal> Animais { get; set; }
        public DbSet<CompraGado> CompraGados { get; set; }
        public DbSet<CompraGadoItem> CompraGadoItems { get; set; }
        public DbSet<Pecuarista> Pecuaristas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove pluralização
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Remove exclusão em cascata
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Seta compo string como varchar
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Tamanho maximo do varchar de 150
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(150));
        }
    }
}
