using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using FearAndHunger2Wiki.Repositories;

var builder = WebApplication.CreateBuilder(args);

// �cie�ki do plik�w JSON
var postaciFilePath = Path.Combine(Directory.GetCurrentDirectory(), "postaci.json");
var artykulyFilePath = Path.Combine(Directory.GetCurrentDirectory(), "artykuly.json");

// Dodaj us�ugi do kontenera DI
builder.Services.AddControllersWithViews();

// Rejestracja repozytori�w jako singleton�w
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

// Dodaj t� lini�, aby obs�ugiwa� CoinFlipController
app.MapControllerRoute(
    name: "CoinFlip",
    pattern: "CoinFlip",
    defaults: new { controller = "CoinFlip", action = "Index" });

app.Run();
