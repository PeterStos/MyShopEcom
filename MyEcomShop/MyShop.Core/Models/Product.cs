using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Core.Models
{
    public class Product
    {
        public string Id { get; set; }

        [StringLength(20)] //Set maximum length of 20 characters
        [DisplayName("Product Name")]
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0,1000)]
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Image { get; set; } // contain a URL

        /// <summary>
        /// Constructor to generate Id for every new instance
        /// </summary>
        public Product()
        {
            this.Id = Guid.NewGuid().ToString();
        }

    }
}
