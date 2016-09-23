using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    public abstract class Item
    {
        protected int itemQty;

        public int GetItemQuantity()
        {
            return itemQty;
        }

    }
}
