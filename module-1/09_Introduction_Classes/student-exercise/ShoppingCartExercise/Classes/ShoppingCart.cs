using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechElevator.Classes
{
    /// <summary>
    /// A shopping cart class stores items in it.
    /// </summary>
    public class ShoppingCart
    {
        public int TotalNumberOfItems { get; private set; } = 0;

        public decimal TotalAmountOwed { get; private set; } = 0.0M;

        public decimal GetAveragePricePerItem()
        {
            if (TotalNumberOfItems == 0)
            {
                return 0.00M;
            }
            return TotalAmountOwed / TotalNumberOfItems;
        }
        public void AddItems(int numberOfItems, decimal pricePerItem)
        {
            TotalNumberOfItems += numberOfItems;
            TotalAmountOwed += (numberOfItems * pricePerItem);
        }
        public void Empty()
        {
            TotalNumberOfItems = 0;
            TotalAmountOwed = 0;
        }
    }
}
