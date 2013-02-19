using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingPal.Models
{
    public class WDItem:IWallItem
    {
        [Key]
        public int Id { get; set; }

       

        public int ItemId { get; set; }

        public DateTime GotAt { get; set; }

        public String Name { get; set; }

        public String Description { get; set; }

        public String ShopName { get; set; }

        public bool IsPublished { get; set; }

        public decimal CreditEarned { get; set; }

        public Guid UserId { get; set; }
        public long ShopItemsId { get; set; }

        public virtual ShopItems ShopItem { get; set; }
        public virtual  User User { get; set; }

        #region IWallItem Members

       

        public Shop Shop
        {
            get
            {
                return ShopItem.Shop;
            }
         
        }

        public int StyleCollectionId
        {
            get
            {
                return ShopItem.StyleCollectionId;
            }
      
        }

        public string ImageLocation
        {
            get
            {
                return ShopItem.ImageLocation;
            }
         
        }

        public decimal Price
        {
            get
            {
                return ShopItem.Price;
            }
          
        }

        public decimal Credit
        {
            get
            {
                return ShopItem.Credit;
            }
          
        }

        public DateTime AddedAt
        {
            get
            {
                return GotAt;
            }
            
        }

        #endregion
    }
}