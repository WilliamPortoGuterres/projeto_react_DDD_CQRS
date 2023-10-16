using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Infrastructure.Data;
using Domain.Interfaces;
using Domain.Handlers;
using Application.Services;
using Application.Interfaces;
using Infrastructure.Interfaces;
using Infrastructure.Repository.Dapper;
using Microsoft.Data.Sqlite;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllersWithViews();
builder.Services.AddControllers();
builder.Services.AddDbContext<RebornLoginContext>(options => 
{
    options.UseSqlite("Data Source=BabyReborn.db");
    
});
builder.Services.AddTransient<IDbConnection>(b =>
{
    return new SqliteConnection("Data Source=BabyReborn.db");
});

builder.Services.AddTransient<IUserHandle, UserHandle>();
builder.Services.AddTransient<ILoginService, LoginService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<ILoginHandle, LoginHandle>();
builder.Services.AddTransient<IUsuarioService, UsuarioService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();





app.MapControllerRoute(
    name: "api",
    pattern: "api/{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
