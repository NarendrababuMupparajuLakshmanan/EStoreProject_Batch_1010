using Discount.Application;
using DIscount.Infrastructure;
using DIscount.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices();

builder.Services.AddControllers();

//Add Swashe Buckle to Services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string _connectionString = 
    builder.Configuration.GetConnectionString("DbConnection");

builder.Services.AddDbContext<DiscountRepository>(options =>
{
    options.UseSqlServer(_connectionString);
});

builder.Services.AddDbContext<ProductRepository>(options =>
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
