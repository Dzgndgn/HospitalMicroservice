using Doccure.PrescriptionService.Context;
using Doccure.PrescriptionService.Mappings;
using Doccure.PrescriptionService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PrescriptionContext>(context =>
{
    context.UseNpgsql(builder.Configuration.GetConnectionString("PostgreConnection"));
});
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(config => { }, typeof(GeneralMappings).Assembly);
builder.Services.AddSwaggerGen();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
//builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
   // app.MapOpenApi();
   app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
