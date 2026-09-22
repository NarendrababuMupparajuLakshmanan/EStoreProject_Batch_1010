using Catalog.Application;
using Catalog.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Call Dependecis Class to collect all MediatR Object
builder.Services.RegisterServices();

//Add Swashe Buckle to Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

string _connectionString = builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<BrandRepository>(options =>
{
    options.UseSqlServer(_connectionString);
});

builder.Services.AddDbContext<TypeRepository>(options =>
{
    options.UseSqlServer(_connectionString);
});

var app = builder.Build();

app.UseRouting();

app.MapControllers();

app.UseSwagger();
app.UseSwaggerUI();

//enable swagger as a default page
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");

    // Make Swagger the default page
    c.RoutePrefix = string.Empty;
});

app.Run();
