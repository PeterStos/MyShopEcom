using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Basket : BaseEntity
    {
        public virtual ICollection<BasketItem> BasketItems { get; set; }

        /// <summary>
        /// Constructor to create an empty list of basket items on creation
        /// </summary>
        public Basket()
        {
            this.BasketItems = new List<BasketItem>();
        }
    }
}
