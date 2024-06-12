using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcAssagnment1.Repositories;
using MvcAssagnment1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession(); // Add this line to configure session state

// Register the PeopleRepo and PeopleService for dependency injection
builder.Services.AddSingleton<IPeopleRepo, PeopleRepo>();
builder.Services.AddTransient<IPeopleService, PeopleService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseSession(); // Add this line to enable session middleware

app.MapControllerRoute(
    name: "feverCheck",
    pattern: "FeverCheck",
    defaults: new { controller = "Doctor", action = "FeverCheck" });

app.MapControllerRoute(
    name: "guessingGame",
    pattern: "GuessingGame",
    defaults: new { controller = "Game", action = "GuessingGame" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "people",
    pattern: "{controller=People}/{action=Index}/{id?}");

app.Run();

