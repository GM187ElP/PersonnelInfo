using Microsoft.Extensions.Options;
using PersonnelInfo.Infrastructure.Configuration;
using PersonnelInfo.Infrastructure.Data.Seeders;

var dbContext = new DatabaseContext();

/*
dbContext.Database.EnsureDeleted();
dbContext.Database.EnsureCreated();


var jobt = new JobTitleSeeder(dbContext);
var citySeeder = new CitySeeder(dbContext);

await jobt.SeedJobTitlesFromJson();
await citySeeder.SeedCitiesFromJson();

Console.WriteLine("Cities have been seeded successfully.");

*/