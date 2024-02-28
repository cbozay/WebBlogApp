using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebBlogApp.Core.Entities;
using WebBlogApp.Entity.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace WebBlogApp.Entity.Entities
{
    public class Article:EntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount{ get; set; }
        public Guid CategoryId{ get; set; }
        public Category Category { get; set; }
        public Guid? ImageId { get; set; }
        public Image Image { get; set; }
        public Guid UserId { get; set; }//Bu ve aşağıdaki navigation property ler 1 makalenin 1 tane user ı olmasını sağlar...
        public AppUser User { get; set; }
    }
}
//Bir class birden fazla interfaceden miras alabilmekteyken, sadece bir class dan miras alabilmektedir.
//Bu durumda class ve interfaceler miras alınacaksa şayet önce miras alınan class yazılır daha sonra interfaceler yazılmalıdır.
//Yani public class Article:EntityBase,IEntityBase şeklinde olmalıdır. Tabi biz IEntityBase yi EntityBase class ında miras
//aldığımızdan dolayı tekrar tekrar miras almıyoruz. Bu nedenle Article class ı içerisinde sadece EntityBase yi miras alırsak şayet
//IEntityBase yi de miras almış oluruz...

