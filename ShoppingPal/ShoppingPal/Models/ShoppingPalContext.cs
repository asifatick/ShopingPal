using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppingPal.Models
{
    public class ShoppingPalContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, add the following
        // code to the Application_Start method in your Global.asax file.
        // Note: this will destroy and re-create your database with every model change.
        // 
        // System.Data.Entity.Database.SetInitializer(new System.Data.Entity.DropCreateDatabaseIfModelChanges<ShoppingPal.Models.ShoppingPalContext>());

        public DbSet<ShoppingPal.Models.Shop> Shops { get; set; }

        public DbSet<ShoppingPal.Models.City> Cities { get; set; }

        public DbSet<ShoppingPal.Models.PO> POes { get; set; }

        public DbSet<ShoppingPal.Models.StyleCollection> StyleCollections { get; set; }

        public DbSet<ShoppingPal.Models.ShopItems> ShopItems { get; set; }

        public DbSet<ShoppingPal.Models.FriendMap> FriendMaps { get; set; }

        public DbSet<ShoppingPal.Models.Settings> Settings { get; set; }

        public DbSet<ShoppingPal.Models.WDItem> WDItems { get; set; }

        public DbSet<User> Users { get; set; }
    }
}