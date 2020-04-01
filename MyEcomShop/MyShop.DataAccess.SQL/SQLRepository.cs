using MyShop.Core.Contracts;
using MyShop.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.DataAccess.SQL
{
    public class SQLRepository<T> : IRepository<T> where T : BaseEntity
    {
        internal DataContext context; // from DataContext in MyShop.DataAccess.SQL
        internal DbSet<T> dbSet; // 

        /// <summary>
        /// Constructor of context and dbSet
        /// </summary>
        /// <param name="context"></param>
        public SQLRepository(DataContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T>();
        }
        public IQueryable<T> Collection()
        {
            return dbSet;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        public void Delete(string Id)
        {
            var t = Find(Id);
            if(context.Entry(t).State == EntityState.Detached)
            {
                dbSet.Attach(t);
            }
            dbSet.Remove(t);
        }

        public T Find(string Id)
        {
            return dbSet.Find(Id);
        }

        public void Insert(T t)
        {
            dbSet.Add(t);
        }

        public void Update(T t)
        {
            // Attach the entity that it needs to update
            dbSet.Attach(t); // pass the object to the entity we need to upadte
            // Tell the Framework to call the Save Changes method to look for this object and persist to the database
            context.Entry(t).State = EntityState.Modified; 
        }
    }

}
