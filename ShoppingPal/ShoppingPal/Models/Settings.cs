using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppingPal.Models
{
    public class Settings
    {
        [Key]
        public virtual long Id { get; set; }
        public string  FacebookID { get; set; }
        public int Age { get; set; }
        public DateTime BirthDay { get; set; }
        public int FavColor { get; set; }
        public int FavCollection { get; set; }
        public int Gender { get; set; }

        public int CityId { get; set; }
        public int POId { get; set; }

    }
}