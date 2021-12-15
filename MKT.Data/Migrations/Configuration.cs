using MKT.Entities.Models;

namespace MKT.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MKT.Data.MKTDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MKT.Data.MKTDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Roles.Add(new Rol() {Id = 1, Nombre = "Administrador"});
            context.Roles.Add(new Rol() { Id = 2, Nombre = "Usuario" });
        }
    }
}
