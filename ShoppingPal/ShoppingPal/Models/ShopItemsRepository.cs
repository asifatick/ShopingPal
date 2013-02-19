using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShoppingPal.Models
{ 
    public class ShopItemsRepository : IShopItemsRepository
    {
        ShoppingPalContext context = new ShoppingPalContext();

        public IQueryable<ShopItems> All
        {
            get { return context.ShopItems; }
        }

        public IQueryable<ShopItems> AllIncluding(params Expression<Func<ShopItems, object>>[] includeProperties)
        {
            IQueryable<ShopItems> query = context.ShopItems;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public ShopItems Find(long id)
        {
            return context.ShopItems.Find(id);
        }

        public void InsertOrUpdate(ShopItems shopitems)
        {
            if (shopitems.Id == default(long)) {
                // New entity
                context.ShopItems.Add(shopitems);
            } else {
                // Existing entity
                context.Entry(shopitems).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var shopitems = context.ShopItems.Find(id);
            context.ShopItems.Remove(shopitems);
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

    public interface IShopItemsRepository : IDisposable
    {
        IQueryable<ShopItems> All { get; }
        IQueryable<ShopItems> AllIncluding(params Expression<Func<ShopItems, object>>[] includeProperties);
        ShopItems Find(long id);
        void InsertOrUpdate(ShopItems shopitems);
        void Delete(long id);
        void Save();
    }
}