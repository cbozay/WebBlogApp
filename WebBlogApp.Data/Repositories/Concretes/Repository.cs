using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Core.Entities;
using WebBlogApp.Data.Context;
using WebBlogApp.Data.Repositories.Abstractions;

namespace WebBlogApp.Data.Repositories.Concretes
{
    public class Repository<T> : IRepository<T> where T : class, IEntityBase, new()//Burada belirttiğimiz T herbir entity class ını temsil etmektedir. 
    {//'class,IEntityBase,new()' ifadeleriyle 'T' yi tanımlamış olduk. 'new()' ile hangi entity gelirse gelsin nesnesinin oluşturulabilir olduğunu belirtmiş oluruz.
        private readonly AppDbContext appDbContext;

        public Repository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        private DbSet<T> Table { get => appDbContext.Set<T>(); }
        //Table özelliği için get kullanımı, bir özelliğin okunabilir olduğunu ve bir değeri döndürdüğünü gösterir.
        //Bu durumda, appDbContext.Set<T>() ifadesi, bir DbSet<T> örneğini döndüren bir metottur. Bu kullanım,
        //özellikle bir özellik değerini hesaplamak veya döndürmek için bir metot kullanmak istediğinizde,
        //kısa ve açık bir şekilde bu görevi gerçekleştirmek için kullanılır. Bu nedenle aşağıda her seferinde 
        //'appDbContext.Set<T>()' kodunu tekrar etmek yerine, 'Table' çağrıldığnda 'appDbContext.Set<T>();' e
        //ulaşım sağlayan bir metod property tanımladık.

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            //yukarıda foreach içerisinde bir entity e ait
            //ilişkili ne kadar tablo varsa hepsini sorguya dahil eder.
            return await query.ToListAsync();

            //Expression<Func<T, bool>> predicate = null(Filtreleme İfadesi):
            //Bu parametre, veritabanındaki nesneleri filtrelemek için kullanılır. Expression<Func<T, bool>> türü, bir lambda ifadesini temsil eden bir türdür
            //ve genellikle where koşulu olarak kullanılır.
            //Örneğin, p => p.Age > 18 gibi bir ifadeyi içerebilir. Bu, veritabanındaki nesneleri sadece belirli bir koşulu sağlayanlarla sınırlamak için kullanılır.
            //Eğer bu parametre değer alırsa, sorgu bu koşulu içerecek şekilde uygulanır.

            //params Expression<Func<T, object>>[] includeProperties(İlişkili Tabloları Dahil Etme):
            //Bu parametre, veritabanındaki ilişkili tabloların(örneğin, bir JOIN işlemi) dahil edilmesini sağlar.
            //params anahtar kelimesi, bu parametrenin birden fazla Expression<Func< T, object>> ifadesini kabul edebileceği anlamına gelir.
            //Yani, metodu çağıran kişi, bu parametreye bir veya daha fazla includeProperties ifadesi geçirebilir.
            //Bu, veritabanındaki bir nesnenin belirli bir ilişkili özelliğini çekmek için kullanılır.
            //Örneğin, p => p.Category gibi bir ifade verilebilir.
            //Bu parametreler, metodun çağrıldığı yerde kullanıcının ihtiyacına göre sorguların özelleştirilmesine izin verir.
            //predicate ile belirli bir filtreleme uygulanabilir ve includeProperties ile de ilişkili tabloların dahil edilmesi sağlanabilir.
        }

        public async Task AddAsync(T entity)
        {
            //await appDbContext.Set<T>().Add(entity);
            await Table.AddAsync(entity);
        }

        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = Table;
            if (predicate != null)
                query = query.Where(predicate);
            if (includeProperties.Any())
                foreach (var item in includeProperties)
                    query = query.Include(item);
            return await query.SingleAsync();
            //SingleAsync, sorgu sonucunda yalnızca bir öğe olması beklenir.Birden fazla öğe bulunursa veya
            //hiç öğe bulunmazsa hata fırlatır.
            //Burada FirstOrDefault veya SingleOrDefault da seçebilirdik. Fakat aşağıdaki nedenlerden ötürü bu SingleAsync() kullandık.
            //FirstOrDefault, sorgu sonucunda birden fazla öğe bulunabilir veya hiç öğe bulunmayabilir.
            //Birden fazla öğe varsa ilkini döndürür, hiç öğe yoksa varsayılan değeri(default) döndürür.
            //SingleOrDefault, sorgu sonucunda yalnızca bir öğe olması beklenir.Birden fazla öğe bulunursa veya
            //hiç öğe bulunmazsa hata fırlatır. Burada default bir değer ya da null bir değer dönmesini istemedik.
        }

        public async Task<T> GetByGuidAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            //Ef Core içerisinde Update ye ait bir asenkron fonksiyon bulunmaz. Nedeni;
            //update yapacağımız instance yi id sinden bulup sonra update yapmak gerekmektedir.
            //Yani önce bir get süreci gerekmektedir. Şayet bu süreç içerisinde update sürecini
            //başlatırsam conflict olma ihtimali bulunmaktadır. Fakat herşeye rağmen buradaki 
            //işlemlerimizi asenkron bir şekilde yürütmek istediğimizden, aşağıdaki yöntemi kullanıyoruz.
            //Asenkron tanımı: Birden fazla işi birbirinden bağımsız bir şekilde aynı anda yürütmek demektir.
            await Task.Run(()=>Table.Update(entity));
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            //Update deki durum burada da geçerli...
            await Task.Run(() => Table.Remove(entity));
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> predicate)
        {
            return await Table.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> predicate = null)
        {
            return await Table.CountAsync(predicate);
        }
    }
}
