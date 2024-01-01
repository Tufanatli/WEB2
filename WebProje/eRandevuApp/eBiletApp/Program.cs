using eRandevuApp.Data;
using eRandevuApp.Data.Repositories;
using eRandevuApp.Data.Repositories.Abstract;
using eRandevuApp.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<RandevuDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSqlConnection")));

builder.Services.AddScoped<IDoktorRepository, DoktorRepository>();
builder.Services.AddScoped<IHastaneRepository, HastaneRepository>();
builder.Services.AddScoped<IBashekimRepository, BashekinRepository>();
builder.Services.AddScoped<IPoliklinikRepository, PoliklinikRepository>();
builder.Services.AddScoped<IRandevuRepository, RandevuRepository>();


builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sr => SepetRepository.AlisVerisSepetiniGetir(sr));



builder.Services.AddIdentity<Kullanici, IdentityRole>(
    o => {

        o.Password.RequireDigit = false;
        o.Password.RequireLowercase = false;
        o.Password.RequireUppercase = false;
        o.Password.RequireNonAlphanumeric = false;
        o.Password.RequiredLength = 3;
    }
    ).AddEntityFrameworkStores<RandevuDbContext>();
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
});



builder.Services.AddLocalization(opt => { opt.ResourcesPath = "Resources"; });
builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();
builder.Services.Configure<RequestLocalizationOptions>(
    opt =>
    {
        var cultures = new List<CultureInfo>
        {
                        new CultureInfo("tr"),
                        new CultureInfo("en")
        };
        opt.DefaultRequestCulture = new RequestCulture("tr");
        opt.SupportedCultures = cultures;
        opt.SupportedUICultures = cultures;
    });

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Poliklinik}/{action=Index}/{id?}");
});

RandevuDbInitializer.EklenecekVeriler(app);
RandevuDbInitializer.KullaniciVeRolEkle(app).Wait();

app.Run();