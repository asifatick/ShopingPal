using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShoppingPal.Models
{ 
    public class PORepository : IPORepository
    {
        ShoppingPalContext context = new ShoppingPalContext();

        public IQueryable<PO> All
        {
            get { return context.POes; }
        }

        public IQueryable<PO> AllIncluding(params Expression<Func<PO, object>>[] includeProperties)
        {
            IQueryable<PO> query = context.POes;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public PO Find(int id)
        {
            return context.POes.Find(id);
        }

        public void InsertOrUpdate(PO po)
        {
            if (po.Id == default(int)) {
                // New entity
                context.POes.Add(po);
            } else {
                // Existing entity
                context.Entry(po).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var po = context.POes.Find(id);
            context.POes.Remove(po);
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

    public interface IPORepository : IDisposable
    {
        IQueryable<PO> All { get; }
        IQueryable<PO> AllIncluding(params Expression<Func<PO, object>>[] includeProperties);
        PO Find(int id);
        void InsertOrUpdate(PO po);
        void Delete(int id);
        void Save();
    }
}