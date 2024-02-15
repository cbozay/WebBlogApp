using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Core.Entities;

namespace WebBlogApp.Core.Entities
{
    public abstract class EntityBase : IEntityBase
    {
        public virtual Guid Id { get; set; } = Guid.NewGuid();
        public virtual string CreatedBy { get; set; }
        public virtual string? ModifiedBy { get; set; }
        public virtual string? DeletedBy { get; set; }
        public virtual DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual DateTime? ModifiedDate { get; set; }
        public virtual DateTime? DeletedDate { get; set; }
        public virtual bool IsDeleted { get; set; } = false;
    }
}//Bir entity oluşturulduğunda Id,CreatedDate,IsDeleted gibi property ler mecburen oluşturulup, içleri doldurulmuş olacaktır.
 //Fakat ModifiedBy,DeletedBy,ModifiedDate,DeletedDate gibi property ler başlangıçta oluşturulduğunda içlerinin dolu olması, 
 //sonrada bir düzenlemeye tabi olacağından nullable yapmalıyız...

//Atadığımız default değerleri silip, bunları constructor içerisinde de tanımlayabilirdik:
//public EntityBase()
//{
//    Id = Guid.NewGuid();
//    CreatedDate = DateTime.Now;
//    IsDeleted = false;
//}
//Fakat bu durum performans açısından dezavantaj sağlayabileceğinden dolayı bunu tercih etmedik...