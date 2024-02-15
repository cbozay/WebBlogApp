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
    public class Article:EntityBase,IEntityBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int ViewCount{ get; set; }
        public Guid CategoryId{ get; set; }
        public Category Category { get; set; }
        public Guid ImageId { get; set; }
        public Image Image { get; set; }
    }
}
//Bir class birden fazla interfaceden miras alabilmekteyken, sadece bir class dan miras alabilmektedir.
//Bu durumda class ve interfaceler miras alınacaksa şayet önce miras alınan class yazılır daha sonra interfaceler yazılmalıdır.

