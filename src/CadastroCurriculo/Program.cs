using AutoMapper;
using CadastroCurriculo;
using CadastroCurriculo.Authorization;
using CadastroCurriculo.Extensions;
using CadastroCurriculo.ModelBinders;
using Core.Mappers;
using Data;
using DataBase;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using SindicosInterno.Extensions;
using System.Globalization;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(x =>
{
    x.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
    x.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider());
    x.ModelBinderProviders.Insert(2, new OnlyNumbersBinderProvider());
})
.AddJsonOptions(opts =>
{
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});

var configurations = builder.Configuration.Get<AppSettings>();
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseMySql(
        configurations.DbConnection.ConnectionString, 
        ServerVersion.AutoDetect(configurations.DbConnection.ConnectionString)
    )
);

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders =
        ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

    options.ForwardLimit = null;
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(x =>
    {
        x.LoginPath = "/";
        x.LogoutPath = "/logout";
        x.AccessDeniedPath = "/";
        x.EventsType = typeof(CustomCookieAuthenticationEvents);
    });

builder.Services.AddCors(o => o.AddPolicy("AllowCors", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));

builder.Services.AddScoped<CustomCookieAuthenticationEvents>();

builder.Services.AddSingleton(provider => new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new Maps());
}).CreateMapper());

builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddHttpContextAccessor();
builder.Services.AddAuthenticatedUser();

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
var ptBr = Culture.GetPtBr();

app.UseStaticFiles();
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(ptBr),
    SupportedCultures = new List<CultureInfo> { ptBr },
    SupportedUICultures = new List<CultureInfo> { ptBr }
});

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
