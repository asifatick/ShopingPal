using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingPal.Models
{
    public class Shop
    {
        public long Id { get; set; }

        public string Name { get; set; }
        public string LogoLocation { get; set; }

        public string Description { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public int CityId { get; set; }
        public int POId { get; set; }

        public Decimal Lat { get; set; }
        public decimal Long { get; set; }
        public User Owner { get; set; }

        public virtual List<StyleCollection> Styles { get; set; }
        public virtual List<ShopItems> Items { get; set; }
    }


    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }

    public class PO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class StyleCollection 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconLocation { get; set; }
    }
    public class ShopItems : IWallItem
    {
        public long Id { get; set; }


        public string Name { get; set; }
        public string Description { get; set; }
        public int StyleCollectionId { get; set; }
        public string ImageLocation { get; set; }

        public decimal Price { get; set; }
        public decimal Credit { get; set; }
        public bool IsCreditOnPercent { get; set; }
        public DateTime AddedAt { get; set; }


        public long ShopId { get; set; }

        public virtual Shop Shop { get; set; }


        
    }


}