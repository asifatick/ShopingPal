using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShoppingPal.Models
{ 
    
	public class SettingsRepository : ISettingsRepository
    {
        ShoppingPalContext context = new ShoppingPalContext();

        public IQueryable<Settings> All
        {
            get { return context.Settings; }
        }

        public IQueryable<Settings> AllIncluding(params Expression<Func<Settings, object>>[] includeProperties)
        {
            IQueryable<Settings> query = context.Settings;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Settings Find(long id)
        {
            return context.Settings.Find(id);
        }

        public void InsertOrUpdate(Settings settings)
        {
            if (settings.Id == default(long)) {
                // New entity
                context.Settings.Add(settings);
            } else {
                // Existing entity
                context.Entry(settings).State = EntityState.Modified;
            }
        }

        public void Delete(long id)
        {
            var settings = context.Settings.Find(id);
            context.Settings.Remove(settings);
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

    public interface ISettingsRepository : IDisposable
    {
        IQueryable<Settings> All { get; }
        IQueryable<Settings> AllIncluding(params Expression<Func<Settings, object>>[] includeProperties);
        Settings Find(long id);
        void InsertOrUpdate(Settings settings);
        void Delete(long id);
        void Save();
    }
}