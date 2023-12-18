using Foodiego.Data.Migrations;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Foodiego.Repositories;
using Foodiego.Interfaces;
using Foodiego.Mapping;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<FoodiegoDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("FoodiegoDbContext")));

builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.ListenLocalhost(5001, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<UserProfile>());
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<FoodiegoDbContext>();
    db.Database.Migrate();
}

app.Run();
