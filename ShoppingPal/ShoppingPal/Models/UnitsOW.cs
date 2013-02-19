using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingPal.Models
{
    public class UnitsOW :IDisposable
    {

        public UnitsOW():this(new ShoppingPalContext())
        {
            
        }

        public UnitsOW(ShoppingPalContext context)
        {
            this.context = context;
        }
        private ShoppingPalContext context ;
        private GenericRepository<Shop> _ShopRepository;
        private ItemRepository _ItemRepo;

        private FriendMapRepository _FriendRepo;



        public FriendMapRepository FriendRepository
        {
            get
            {
                if (this._FriendRepo == null)
                {
                    this._FriendRepo = new FriendMapRepository(context);
                }
                return _FriendRepo;
            }

        }
        public ItemRepository ItemRepository
        {
            get {
                if (this._ItemRepo == null)
                {
                    this._ItemRepo = new ItemRepository(context);
                }
                return _ItemRepo;
            }
            
        }
        
        //private CourseRepository courseRepository;

        public GenericRepository<Shop> ShopRepository
        {
            get
            {

                if (this._ShopRepository == null)
                {
                    this._ShopRepository = new GenericRepository<Shop>(context);
                }
                return _ShopRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}