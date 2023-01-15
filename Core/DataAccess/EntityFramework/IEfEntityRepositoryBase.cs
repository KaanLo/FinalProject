using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class IEfEntityRepositoryBase<TEntity,TContext>:IEntityRepository<TEntity>
        where TEntity : class,IEntity,new()
        where TContext:DbContext,new()
    {
        //Kodların ortak koyulduğu ve yönetildiği bir sistem var bunun da adı NuGet
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())               //Çöp toplayıcısı using ile yaparsak işimiz bittiğinde hemen siliyor.Context ler biraz pahalı
            {
                var AddedEntity = context.Entry(entity);      //Girilen entity i tutucaz,Referansını yakalıcaz ama ekleme oldugu ıcın direk eklıcez.

                AddedEntity.State = EntityState.Added;
                context.SaveChanges();


            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var DeletedEntity = context.Entry(entity);
                DeletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);


            }
        }

        public List<TEntity> Getall(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();

            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())               //Çöp toplayıcısı using ile yaparsak işimiz bittiğinde hemen siliyor.Context ler biraz pahalı
            {
                var UpdatedEntity = context.Entry(entity);      //Girilen entity i tutucaz,Referansını yakalıcaz ama ekleme oldugu ıcın direk eklıcez.

                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }




    }
}
