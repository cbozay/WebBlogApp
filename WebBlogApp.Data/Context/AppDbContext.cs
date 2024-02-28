using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebBlogApp.Entity.Entities;

namespace WebBlogApp.Data.Context
{
    public class AppDbContext : IdentityDbContext<AppUser,AppRole,Guid,AppUserClaim,AppUserRole,AppUserLogin,AppRoleClaim,AppUserToken>
    {//Identity entity lerini oluşturduktan sonra yukarıda 3. overload ını kullandık...
        protected AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }    
        public DbSet<Category> Categories { get; set; }    
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);//Bunu IdentityDbContext integrasyonundan sonra ekledik. Yoksa migration sırasında hata alınır...
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //Bu metod Assemly deki IEntityTypeConfiguration<> dan türeyen sınıfların
            //tüm metodlarını bulup DbContext in içerisinde boş olarak bulunan OnModelCreating
            //içerisine yazar/override eder... Böyle yaptık çünkü daha temiz ve modüler bir
            //kod sağlamaktadır...
        }

    }
}
//DbContext üzerine gelip ctrl+. bastığımızda iki adet 
//constructor generate etme seçeneği bulunmaktadır. Biz önce
//boş bir constructor generate ettikten sonra 'options'
//olanı da oluşturuyoruz. Daha sonra DbContextOptions e
//kendi dbContext imi bu şekilde '<AppDbContext>' ekliyorum.