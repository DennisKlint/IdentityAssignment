namespace IdentityAssignment.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<IdentityAssignment.Models.IdentityDbModels>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(IdentityAssignment.Models.IdentityDbModels context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Countries.AddOrUpdate(x => x.ID,
                new CountryModels() { ID = 1, CountryName = "Sweden"},
                new CountryModels() { ID = 2, CountryName = "France" },
                new CountryModels() { ID = 3, CountryName = "Slovakia" }
            );

            context.Cities.AddOrUpdate(x => x.ID,
                new CityModels() { ID = 1, CountryModelsID = 1, CityName = "Stockholm" },
                new CityModels() { ID = 2, CountryModelsID = 1, CityName = "Göteborg" },
                new CityModels() { ID = 3, CountryModelsID = 2, CityName = "Paris" },
                new CityModels() { ID = 4, CountryModelsID = 2, CityName = "Nice" },
                new CityModels() { ID = 5, CountryModelsID = 3, CityName = "Bratislava" },
                new CityModels() { ID = 6, CountryModelsID = 3, CityName = "Nitra" }
                );

            context.People.AddOrUpdate(x => x.ID,
                new PersonModels() { ID = 1, CityModelsID = 1, Name = "Bob" },
                new PersonModels() { ID = 2, CityModelsID = 1, Name = "Steve" },
                new PersonModels() { ID = 3, CityModelsID = 2, Name = "Pelle" },
                new PersonModels() { ID = 4, CityModelsID = 2, Name = "Sten" },
                new PersonModels() { ID = 5, CityModelsID = 3, Name = "Anna" },
                new PersonModels() { ID = 6, CityModelsID = 3, Name = "Fillip" },
                new PersonModels() { ID = 7, CityModelsID = 4, Name = "Kent" },
                new PersonModels() { ID = 8, CityModelsID = 4, Name = "Mikael" },
                new PersonModels() { ID = 9, CityModelsID = 5, Name = "Monika" },
                new PersonModels() { ID = 10, CityModelsID = 5, Name = "Norton" },
                new PersonModels() { ID = 11, CityModelsID = 5, Name = "Magnus" },
                new PersonModels() { ID = 12, CityModelsID = 6, Name = "Bert" },
                new PersonModels() { ID = 13, CityModelsID = 6, Name = "Lisa" }
                );
        }
    }
}
