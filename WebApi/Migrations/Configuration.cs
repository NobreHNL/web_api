namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApi.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Models.WebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApi.Models.WebApiContext context)
        { 
            context.Pecuaristas.AddOrUpdate(x => x.Id,
                new Pecuarista() { Id = 1, Nome = "Jane Austen" },
                new Pecuarista() { Id = 2, Nome = "Charles Dickens" },
                new Pecuarista() { Id = 3, Nome = "Miguel de Cervantes" }
            );

            context.Animais.AddOrUpdate(x => x.Id,
                new Animal(){Id = 1, Descricao = "Boi Nelore", Preco = "20.000"},
                new Animal(){Id = 2, Descricao = "Boi Marchigiana", Preco = "5.000"},
                new Animal(){Id = 2, Descricao = "Boi Hereford", Preco = "15.000"}
            );
        }
    }
}
