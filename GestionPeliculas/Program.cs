using GestionPeliculas.Data.EF;
using GestionPeliculas.Logica;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();

builder.Services.AddScoped<GestionPeliculasContext>();
builder.Services.AddScoped<IPeliculasLogica, PeliculasLogica>();
builder.Services.AddScoped<IGenerosLogica, GenerosLogica>();

var app = builder.Build();


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
    pattern: "{controller=Peliculas}/{action=Agregar}/{id?}");

app.Run();
