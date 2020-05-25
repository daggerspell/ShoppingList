using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class ShoppingListItem
    {
        public Item item;
        public int Quanity;

        public ShoppingListItem(Item newItem, int quanity)
        {
            item = newItem;
            Quanity = quanity;
        }

        public void AddQuanity()
        {
            Quanity++;
        }

        public void RemoveQuanity()
        {
            Quanity--;
        }

        public double SetTotalPrice()
        {
            return item.Price * Quanity;
        }

    }
}
