using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using FearAndHunger2Wiki.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Œcie¿ki do plików JSON
var postaciFilePath = Path.Combine(Directory.GetCurrentDirectory(), "postaci.json");
var artykulyFilePath = Path.Combine(Directory.GetCurrentDirectory(), "artykuly.json");

// Dodaj us³ugi do kontenera DI
builder.Services.AddControllersWithViews();

// Rejestracja repozytoriów jako singletonów
builder.Services.AddSingleton<JsonFilePostaciRepository>(sp => new JsonFilePostaciRepository(postaciFilePath));
builder.Services.AddSingleton<JsonFileArtykulyRepository>(sp => new JsonFileArtykulyRepository(artykulyFilePath));

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Dodaj tê liniê, aby obs³ugiwaæ CoinFlipController
app.MapControllerRoute(
    name: "CoinFlip",
    pattern: "CoinFlip",
    defaults: new { controller = "CoinFlip", action = "Index" });

app.Run();
