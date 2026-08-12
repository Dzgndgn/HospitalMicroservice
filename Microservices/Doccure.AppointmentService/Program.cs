using Doccure.AppointmentService.Context;
using Doccure.AppointmentService.Mappings;
using Doccure.AppointmentService.Services.AppointmentDetailServices;
using Doccure.AppointmentService.Services.AppointmentServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentDetailServices, AppointmentDetailService>();
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddAutoMapper(config => { },typeof(GeneralMappings));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
