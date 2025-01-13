using Microsoft.Extensions.Options;
using PersonnelInfo.Infrastructure.Configuration;
using PersonnelInfo.Infrastructure.Data.Seeders;

var dbContext = new DatabaseContext();
var citySeeder = new CitySeeder(dbContext);

// Ensure the database is deleted and created
dbContext.Database.EnsureDeleted(); // Deletes existing database
dbContext.Database.EnsureCreated(); // Creates new database

// Seed cities from JSON
await citySeeder.SeedCitiesFromJson();

Console.WriteLine("Cities have been seeded successfully.");