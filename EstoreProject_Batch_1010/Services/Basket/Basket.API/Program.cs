using Basket.Core.Repositories;
using Basket.Core.Settings;
using Basket.Infrastructure;
using Basket.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterBasketServices();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CacheSetting>(
        builder.Configuration.GetSection("ConnectionString"));

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration
        = builder.Configuration.GetSection("CacheSetting").GetValue<string>("ConnectionString");
});

builder.Services.AddScoped<IBasketRepository, BasketRepository>();

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
