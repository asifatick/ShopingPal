using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace ShoppingPal.Models
{
    public class FriendMap
    {
        [Key]
        public int Id { get; set; }

        public long UserID { get; set; }
        public long FriendID { get; set; }
        public bool IsFollower { get; set; }
        public bool IsGuru { get; set; }

        public virtual User Friend { get; set; }

      
    }
}