using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShoppingPal.Models;

namespace ShoppingPal.Models
{
   public interface IWallItem
    {
       string Name { get; }
       string Description { get;}
       Shop Shop { get;  }
        int StyleCollectionId { get;  }
        string ImageLocation { get;  }

        decimal Price { get;  }
        decimal Credit { get; }
       DateTime AddedAt { get;  }
    }
}
