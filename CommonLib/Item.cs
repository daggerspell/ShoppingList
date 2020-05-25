using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class Item
    {
    
        public string Name;
        public string Description;
        public double Price;
        public bool Taxable;
        public string IsleLocation;
        
        public Item()
        {
        }

        public Item(string itemName, string itemDescript, double price, bool tax, string isleInfo )
        {
            Name = itemName;
            Description = itemDescript;
            Price = price;
            Taxable = tax;
            IsleLocation = isleInfo;
        }
    }
}

