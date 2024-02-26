using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
            services.AddScoped<IArticleService,ArticleService>();
        }
    }
}
