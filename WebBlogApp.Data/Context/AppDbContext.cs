using Microsoft.EntityFrameworkCore;
using WebBlogApp.Entity.Entities;

namespace WebBlogApp.Data.Context
{
    public class AppDbContext : DbContext
    {
        protected AppDbContext()
        {
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }    
        public DbSet<Category> Categories { get; set; }    
        public DbSet<Image> Images { get; set; }    
        
        
    }
}
//DbContext üzerine gelip ctrl+. bastığımızda iki adet 
//constructor generate etme seçeneği bulunmaktadır. Biz önce
//boş bir constructor generate ettikten sonra 'options'
//olanı da oluşturuyoruz. Daha sonra DbContextOptions e
//kendi dbContext imi bu şekilde '<AppDbContext>' ekliyorum.