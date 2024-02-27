using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Service.Services.Abstractions;
using WebBlogApp.Service.Services.Concretes;

namespace WebBlogApp.Service.Services.Extentions
{
    public static class Registration
    {
        public static void AddServices(this IServiceCollection services) 
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddScoped<IArticleService,ArticleService>();
            services.AddAutoMapper(assembly);
            //Buradaki assembly ile Services katmanındaki tüm class lar taranır.
            //AddAutoMapper ihtiyacı olan tüm Profile den türeyen sınıfları tanıyıp
            //DI kaydını yapar.
        }
    }
}
