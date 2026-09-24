using Doccure.MarketService.Context;
using Doccure.MarketService.Mappings;
using Doccure.MarketService.Services.ProductServices;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration =builder.Configuration.GetConnectionString("Redis");
    options.InstanceName = "MarketService";
});
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IProductServices, ProductServices>();
builder.Services.AddDbContext<ProductDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddAutoMapper(config => { }, typeof(GeneralMappings));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
