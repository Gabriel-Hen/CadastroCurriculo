using CadastroCurriculo;
using DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var configurations = builder.Configuration.Get<AppSettings>();
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseMySql(
        configurations.DbConnection.ConnectionString, 
        ServerVersion.AutoDetect(configurations.DbConnection.ConnectionString)
    )
);

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

app.Run();
