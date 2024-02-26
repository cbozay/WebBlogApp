using Microsoft.EntityFrameworkCore;
using WebBlogApp.Data.Context;
using WebBlogApp.Data.Extentions;
using WebBlogApp.Service.Services.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataLayer(builder.Configuration);
//Yazd���m�z bu extention metod i�erisinde 'configuration'
//metodunu kullanaca��m�zdan �t�r� parametre olarak yollad�k.
builder.Services.AddServices();

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

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

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapDefaultControllerRoute();
//Yukar�daki route lerin her ikisi de ayn� �eyi ifade eder. 
//�kincisi birincisinin sadele�tirilmi� halidir. Bunlardan ikinisi de 
//kullanmay�p ui-admin route ayr�m� yapaca��m�zdan a�a��daki custom
//route yap�s�ndan devam ediyoruz...
#pragma warning disable ASP0014 //A�a��daki ye�il �izgi �nerisini disable yapt�k...
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Home}/{action=Index}/{id?}");
    //MapAreaControllerRoute �zerine fareyle geldi�imizde benden
    //name,areaName ve pattern bilgilerini girmemi zorunlu tutmaktad�r.
    //Bu parametreleri girmedi�imiz m�ddet�e k�rm�z� �izgi g�r�n�r.
    //K��eli parantez i�erisinde g�r�nen parametreleri de zorunlu olmay�p
    //opsiyoneldir.

    endpoints.MapDefaultControllerRoute();
});

app.Run();
