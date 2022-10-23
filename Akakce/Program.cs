using Akakce.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Service.Services.Handlers.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AkakceContext>(options =>
                    options.UseNpgsql(builder.Configuration.GetConnectionString("AkakceContext")));

// Add mediatr
builder.Services.AddMediatR(typeof(IHandler).Assembly);

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
