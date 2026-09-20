using Doccure.QueueService.Context;
using Doccure.QueueService.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<QContext>();
builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy("WebUICors", policy =>
    {
        policy.WithOrigins("https://localhost:7078").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("WebUICors");
app.UseAuthorization();

app.MapControllers();
app.MapHub<QueueHub>("/queueHub");
app.Run();
