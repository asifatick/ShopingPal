using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShoppingPal.Models
{ 
    public class WDItemRepository : IWDItemRepository
    {
        ShoppingPalContext context = new ShoppingPalContext();

        public IQueryable<WDItem> All
        {
            get { return context.WDItems; }
        }

        public IQueryable<WDItem> AllIncluding(params Expression<Func<WDItem, object>>[] includeProperties)
        {
            IQueryable<WDItem> query = context.WDItems;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public WDItem Find(int id)
        {
            return context.WDItems.Find(id);
        }

        public void InsertOrUpdate(WDItem wditem)
        {
            if (wditem.Id == default(int)) {
                // New entity
                context.WDItems.Add(wditem);
            } else {
                // Existing entity
                context.Entry(wditem).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var wditem = context.WDItems.Find(id);
            context.WDItems.Remove(wditem);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface IWDItemRepository : IDisposable
    {
        IQueryable<WDItem> All { get; }
        IQueryable<WDItem> AllIncluding(params Expression<Func<WDItem, object>>[] includeProperties);
        WDItem Find(int id);
        void InsertOrUpdate(WDItem wditem);
        void Delete(int id);
        void Save();
    }
}