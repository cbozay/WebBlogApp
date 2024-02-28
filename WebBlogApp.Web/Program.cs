using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebBlogApp.Data.Context;
using WebBlogApp.Data.Extentions;
using WebBlogApp.Entity.Entities;
using WebBlogApp.Service.Services.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataLayer(builder.Configuration);
//Yazd���m�z bu extention metod i�erisinde 'configuration'
//metodunu kullanaca��m�zdan �t�r� parametre olarak yollad�k.
builder.Services.AddServices();

builder.Services.AddSession();//A�a��dan middleware sini ekledik...

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    //Burada password i�in gev�etti�imiz opsiyonel ayarlar� test a�amas�nda
    //password girerken �ok zorlanmayal�m diye yapt�k. Yoksa proje canl�ya
    //��kt���nda bu opsiyonlar� gev�etmek do�ru de�ildir...
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
}).AddRoleManager<RoleManager<AppRole>>()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();//Burada AppUser ve AppRole s�n�flar� olu�turulmam��sa
//yerine IdentityUser ve IdentityRole yaz�labilmektedir...
//Role based authentication yapmak i�in AddRoleManager ekledik...

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");//Herhangi bir yetkisi
    //bulunmayan bir kullan�c�, yetki gerektiren bir sayfaya(AdminPAge) girmeye �al��t���nda
    //kullan�c�y� "LoginPage" ye navigate eder...Buradaki "Admin" area y�, "Auth" controller i
    //"Login" ise action u temsil eder...
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name="WebBlogApp",//Herhangi bir isim olabilir..
        HttpOnly=true,
        SameSite=SameSiteMode.Strict,
        SecurePolicy=CookieSecurePolicy.SameAsRequest//Bununla uygulamam�z hem http hem de https den 
        //istek alabilmektedir...Tabiki bu durum, uygulama canl�ya ��kt���nda istenmayan bir durumdur.
        //SameAsRequest opsiyonu yerine Always opsiyonu tercih edilmelidir...
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);//Login olduktan sonra olu�turulan cookie cihazda 7 g�n
    //boyunca tutulabilmektedir. B�ylece 7 g�n i�erisinde uygulamam tekrar bir login istemeyecektir...
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");//Yetkisiz bir giri� yap�lmaya 
    //�al���ld���nda bu sayfaya y�nlendirilerek kullan�c�ya gerekli uyar�lar yap�lmaktad�r... Bu senaryo
    //genelde S�perAdmin yetkilerini kullanmaya �al��an Admin yetkisindeki kullan�c�lar i�in ge�erlidr.
});

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

app.UseSession();

app.UseRouting();

app.UseAuthentication();//Bu middleware UseAuthorization un �zerinde olmas� mecburidir...
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
