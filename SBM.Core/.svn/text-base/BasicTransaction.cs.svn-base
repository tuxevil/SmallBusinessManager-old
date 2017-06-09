using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SBM.Core
{
    public abstract class BasicTransaction : Entity
    {
        public Customer Customer { get; set; }
        private List<SubProductForTransaction> subProductsForTransactions = new List<SubProductForTransaction>();
        public decimal Total { get; set; }
        public TransactionType Type { get; set; }
        private bool locked;

        public List<SubProductForTransaction> SubProductsForTransactions
        {
            get { return subProductsForTransactions; }
            set { subProductsForTransactions = value; }
        }

        public bool Locked
        {
            get { return locked; }
        }

        public void Lock()
        {
            this.locked = true;
        }

        public void UnLock()
        {
            this.locked = false;
        }
    }

    public enum TransactionType
    {
        Quote = 1,
        Sale = 2
    }
}
