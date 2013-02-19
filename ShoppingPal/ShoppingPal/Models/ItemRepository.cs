using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShoppingPal.Models
{
    public class ItemRepository
    {
        private ShoppingPalContext context;

        public ItemRepository(ShoppingPalContext context)
        {
            // TODO: Complete member initialization
            this.context = context;
        }
        internal List<IWallItem> GetWallItemsForUser(string UserName)
        {
            List<IWallItem> wItems,wdItems;
            wItems = context.ShopItems.OrderBy(ad => ad.AddedAt).Take(30).ToList<IWallItem>();
            wdItems = context.WDItems.OrderBy(ad => ad.AddedAt).Take(30).ToList<IWallItem>();

            wItems.Union(wdItems);




            return wItems;
        }

        internal List<WDItem> GetWardDroppedItems(int itemID)
        {
            return context.WDItems.Include("User").Where(w => w.ItemId == itemID).ToList();
        }
    }
}
