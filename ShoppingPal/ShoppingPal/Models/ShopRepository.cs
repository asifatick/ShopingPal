using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShoppingPal.Models
{ 
    
	public class ShopRepository : IShopRepository
    {
        ShoppingPalContext context = new ShoppingPalContext();

        public IQueryable<Shop> All
        {
            get { return context.Shops; }
        }

        public IQueryable<Shop> AllIncluding(params Expression<Func<Shop, object>>[] includeProperties)
        {
            IQueryable<Shop> query = context.Shops;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Shop Find(long id)
        {
            return context.Shops.Find(id);
        }

        public void InsertOrUpdate(Shop shop)
        {
            if (shop.Id == default(long)) {
                // New entity
                context.Shops.Add(shop);
            } else {
                // Existing entity
                context.Entry(shop).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var shop = context.Shops.Find(id);
            context.Shops.Remove(shop);
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

    public interface IShopRepository : IDisposable
    {
        IQueryable<Shop> All { get; }
        IQueryable<Shop> AllIncluding(params Expression<Func<Shop, object>>[] includeProperties);
        Shop Find(long id);
        void InsertOrUpdate(Shop shop);
        void Delete(long id);
        void Save();
    }
}