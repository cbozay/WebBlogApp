using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebBlogApp.Core.Entities
{
    public interface IEntityBase
    {
    }
}
//Bir class oluştururken interface sini oluşturmak, o class ın imzasını olulturmak demektir.
//Bu durumun avantajı ise ister aynı developer ister farklı developer tarafından kod üzerinde yapılacak 
//herhangi bir değişiklik durumunda, yapılacak değişikliği imza çerçevesinde yapmasını zorunlu tutmuş oluruz.
//Bu da kodumuzun yapısının bozulmamasını ve kodumuzu korumamızı sağlar.