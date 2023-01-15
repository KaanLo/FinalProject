using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    //Core katmanı evrensel katman.Bütün .NET projelerinde kullanabilirim anlamına geliyor.
    //Core katmanı diğer katmanları referans almaz çünkü h,çbir yere bağlı olmaması gerekir.

    public interface IEntityRepository<T>where T : class,IEntity,new()
    {
        //Bu yapıyı sadece 1 kere yazıyoruz.Filtreleme yapmada kullanılıyor,zamanla anlicakmışım.
        //Burada yazan, Class olabilir demek değil Referans Tip olabilir demektir.
        //IEntity olabilir yada IEntity implemente eden bir nesne olabilir.

        List<T> Getall(Expression<Func<T,bool>>filter=null);
        T Get(Expression<Func<T, bool>> filter);   //Burdaki detay bilgileri inmek için.Üstteki kod ile filtreye göre liste gelir burdan da detayına inersin.
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        


    }
}
