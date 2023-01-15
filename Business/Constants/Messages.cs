using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages           //Static verdiğin zaman new lemiyorsun direk kullanabiliyorsun.
    {
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductNameInvalid = "Ürün ismi gecersiz.";
        internal static string MaintenanceTime= "Sistem bakımda";
        internal static string ProductsListed = "Ürünler Listelendi";
        internal static string CategoryLimitExceed = "Kategori Limiti asıldıgı ıcın yenı urun eklenemiyor";
    }
}
