using Microsoft.EntityFrameworkCore;
using WebBlogApp.Data.Context;
using WebBlogApp.Data.Extentions;
using WebBlogApp.Service.Services.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataLayer(builder.Configuration);
//Yazdýðýmýz bu extention metod içerisinde 'configuration'
//metodunu kullanacaðýmýzdan ötürü parametre olarak yolladýk.
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
//Yukarýdaki route lerin her ikisi de ayný þeyi ifade eder. 
//Ýkincisi birincisinin sadeleþtirilmiþ halidir. Bunlardan ikinisi de 
//kullanmayýp ui-admin route ayrýmý yapacaðýmýzdan aþaðýdaki custom
//route yapýsýndan devam ediyoruz...
#pragma warning disable ASP0014 //Aþaðýdaki yeþil çizgi önerisini disable yaptýk...
app.UseEndpoints(endpoints =>
{
    endpoints.MapAreaControllerRoute(
        name:"Admin",
        areaName:"Admin",
        pattern:"Admin/{controller=Home}/{action=Index}/{id?}");
    //MapAreaControllerRoute üzerine fareyle geldiðimizde benden
    //name,areaName ve pattern bilgilerini girmemi zorunlu tutmaktadýr.
    //Bu parametreleri girmediðimiz müddetçe kýrmýzý çizgi görünür.
    //Köþeli parantez içerisinde görünen parametreleri de zorunlu olmayýp
    //opsiyoneldir.

    endpoints.MapDefaultControllerRoute();
});

app.Run();
