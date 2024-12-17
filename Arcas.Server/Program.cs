using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using sqlTest.Server.Data;
using sqlTest.Server.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ArcasDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 40))));

//builder.Services.AddIdentity<User, IdentityRole>() // 使用自定义的 User 类和 IdentityRole（可以根据需要修改）
//    .AddEntityFrameworkStores<ArcasDbContext>()
//    .AddDefaultTokenProviders();

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();