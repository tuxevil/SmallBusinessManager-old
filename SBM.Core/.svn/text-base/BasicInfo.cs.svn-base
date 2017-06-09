using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBM.Core
{
    public abstract class BasicInfo: Entity
    {
        public string Name { get; set; }
        public int StockQuantity { get; set; }

        public void IncreaseStock(int quantity)
        {
            this.StockQuantity += quantity;
        }

        public void DecreaseStock(int quantity)
        {
            this.StockQuantity -= quantity;
        }
    }
}
