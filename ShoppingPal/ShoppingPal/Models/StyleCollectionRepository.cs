using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShoppingPal.Models
{ 
    public class StyleCollectionRepository : IStyleCollectionRepository
    {
        ShoppingPalContext context = new ShoppingPalContext();

        public IQueryable<StyleCollection> All
        {
            get { return context.StyleCollections; }
        }

        public IQueryable<StyleCollection> AllIncluding(params Expression<Func<StyleCollection, object>>[] includeProperties)
        {
            IQueryable<StyleCollection> query = context.StyleCollections;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public StyleCollection Find(int id)
        {
            return context.StyleCollections.Find(id);
        }

        public void InsertOrUpdate(StyleCollection stylecollection)
        {
            if (stylecollection.Id == default(int)) {
                // New entity
                context.StyleCollections.Add(stylecollection);
            } else {
                // Existing entity
                context.Entry(stylecollection).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var stylecollection = context.StyleCollections.Find(id);
            context.StyleCollections.Remove(stylecollection);
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

    public interface IStyleCollectionRepository : IDisposable
    {
        IQueryable<StyleCollection> All { get; }
        IQueryable<StyleCollection> AllIncluding(params Expression<Func<StyleCollection, object>>[] includeProperties);
        StyleCollection Find(int id);
        void InsertOrUpdate(StyleCollection stylecollection);
        void Delete(int id);
        void Save();
    }
}