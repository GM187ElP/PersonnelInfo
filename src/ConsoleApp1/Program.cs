using PersonnelInfo.Infrastructure.Configuration;

DatabaseContext context = new();

context.Database.EnsureDeleted();
context.Database.EnsureCreated();

