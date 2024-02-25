using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Data.Context;
using WebBlogApp.Data.Repositories.Abstractions;
using WebBlogApp.Data.Repositories.Concretes;
using WebBlogApp.Data.UnitOfWorks;

namespace WebBlogApp.Data.Extentions
{
    public static class Registration
    {
        public static void AddDataLayer(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            //Burada repository ler için tüm entity class larını temsil eden generic 
            //yapı kurduğumuzdan dolayı IRepository içerisine gelen <T> yi
            //services.AddScoped(IRepository<T>, Repository<T>); şeklinde belirttiğimizde
            //bizden 'T' entity class ını isteyeceğinden, <T> yi typeof() metoduyla almış olduk.
            services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
