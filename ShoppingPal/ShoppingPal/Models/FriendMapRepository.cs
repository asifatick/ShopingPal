using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace ShoppingPal.Models
{ 
    public class FriendMapRepository : IFriendMapRepository
    {
        ShoppingPalContext context ;
        public FriendMapRepository()
            : this(new ShoppingPalContext())
        {
            
        }
        public FriendMapRepository(ShoppingPalContext context)
        {
            // TODO: Complete member initialization
            this.context = context;
        }
        public IQueryable<FriendMap> All
        {
            get { return context.FriendMaps; }
        }

        public IQueryable<FriendMap> AllIncluding(params Expression<Func<FriendMap, object>>[] includeProperties)
        {
            IQueryable<FriendMap> query = context.FriendMaps;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public FriendMap Find(int id)
        {
            return context.FriendMaps.Find(id);
        }

        public void InsertOrUpdate(FriendMap friendmap)
        {
            if (friendmap.Id == default(int)) {
                // New entity
                context.FriendMaps.Add(friendmap);
            } else {
                // Existing entity
                context.Entry(friendmap).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var friendmap = context.FriendMaps.Find(id);
            context.FriendMaps.Remove(friendmap);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }



        internal List<FriendMap> Friends(string userName)
        {
            User user = context.Users.Where(u => u.Username == userName).FirstOrDefault();
            List<FriendMap> fmap = context.FriendMaps.Include("Friend").Where(f => f.UserID == user.UID).OrderBy(f => f.IsGuru).ToList();
            return fmap;
        }
    }

    public interface IFriendMapRepository : IDisposable
    {
        IQueryable<FriendMap> All { get; }
        IQueryable<FriendMap> AllIncluding(params Expression<Func<FriendMap, object>>[] includeProperties);
        FriendMap Find(int id);
        void InsertOrUpdate(FriendMap friendmap);
        void Delete(int id);
        void Save();
    }
}