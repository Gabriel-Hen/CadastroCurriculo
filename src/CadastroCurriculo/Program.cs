using CadastroCurriculo;
using Core.Mappers;
using Data;
using DataBase;
using Microsoft.EntityFrameworkCore;
using SindicosInterno.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var configurations = builder.Configuration.Get<AppSettings>();
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseMySql(
        configurations.DbConnection.ConnectionString, 
        ServerVersion.AutoDetect(configurations.DbConnection.ConnectionString)
    )
);
builder.Services.AddAutoMapper(typeof(Maps));
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddHostedService(serviceProvider => new InitDataBaseServices(serviceProvider));

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var app = builder.Build();

app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseCors("AllowCors");
app.UseStaticFiles();

app.UseRouting();
app.UseCookiePolicy(new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict,
});
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(x =>
{
    x.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.UseStatusCodePagesWithRedirects("/erro/{0}");

app.Run();
