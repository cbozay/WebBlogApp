using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebBlogApp.Data.Context;
using WebBlogApp.Data.Extentions;
using WebBlogApp.Entity.Entities;
using WebBlogApp.Service.Services.Extentions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDataLayer(builder.Configuration);
//Yazdýðýmýz bu extention metod içerisinde 'configuration'
//metodunu kullanacaðýmýzdan ötürü parametre olarak yolladýk.
builder.Services.AddServices();

builder.Services.AddSession();//Aþaðýdan middleware sini ekledik...

// Add services to the container.
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddIdentity<AppUser, AppRole>(opt =>
{
    //Burada password için gevþettiðimiz opsiyonel ayarlarý test aþamasýnda
    //password girerken çok zorlanmayalým diye yaptýk. Yoksa proje canlýya
    //çýktýðýnda bu opsiyonlarý gevþetmek doðru deðildir...
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
}).AddRoleManager<RoleManager<AppRole>>()
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders();//Burada AppUser ve AppRole sýnýflarý oluþturulmamýþsa
//yerine IdentityUser ve IdentityRole yazýlabilmektedir...
//Role based authentication yapmak için AddRoleManager ekledik...

builder.Services.ConfigureApplicationCookie(config =>
{
    config.LoginPath = new PathString("/Admin/Auth/Login");//Herhangi bir yetkisi
    //bulunmayan bir kullanýcý, yetki gerektiren bir sayfaya(AdminPAge) girmeye çalýþtýðýnda
    //kullanýcýyý "LoginPage" ye navigate eder...Buradaki "Admin" area yý, "Auth" controller i
    //"Login" ise action u temsil eder...
    config.LogoutPath = new PathString("/Admin/Auth/Logout");
    config.Cookie = new CookieBuilder
    {
        Name="WebBlogApp",//Herhangi bir isim olabilir..
        HttpOnly=true,
        SameSite=SameSiteMode.Strict,
        SecurePolicy=CookieSecurePolicy.SameAsRequest//Bununla uygulamamýz hem http hem de https den 
        //istek alabilmektedir...Tabiki bu durum, uygulama canlýya çýktýðýnda istenmayan bir durumdur.
        //SameAsRequest opsiyonu yerine Always opsiyonu tercih edilmelidir...
    };
    config.SlidingExpiration = true;
    config.ExpireTimeSpan = TimeSpan.FromDays(7);//Login olduktan sonra oluþturulan cookie cihazda 7 gün
    //boyunca tutulabilmektedir. Böylece 7 gün içerisinde uygulamam tekrar bir login istemeyecektir...
    config.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");//Yetkisiz bir giriþ yapýlmaya 
    //çalýþýldýðýnda bu sayfaya yönlendirilerek kullanýcýya gerekli uyarýlar yapýlmaktadýr... Bu senaryo
    //genelde SüperAdmin yetkilerini kullanmaya çalýþan Admin yetkisindeki kullanýcýlar için geçerlidr.
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

app.UseAuthentication();//Bu middleware UseAuthorization un üzerinde olmasý mecburidir...
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
