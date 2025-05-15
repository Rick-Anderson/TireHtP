using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading.Tasks;
using TireHtP.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
});
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TireHtPContext>(options =>
    options.UseInMemoryDatabase("InMemDB"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.MapStaticAssets();
app.UseSession();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
