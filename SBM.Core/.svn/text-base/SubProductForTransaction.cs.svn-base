using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class SubProductForTransaction : Entity
    {
        public SubProduct SubProduct { get; set; }
        public BasicTransaction Transaction { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }

        public string ProductName
        {
            get { return SubProduct.Product.Name + " - " + SubProduct.Name; }   
        }

        //Para crear nuevos
        public SubProductForTransaction(SubProduct subProduct, BasicTransaction transaction, int quantity, decimal unitPrice)
        {
            this.SubProduct = subProduct;
            this.Transaction = transaction;
            this.Quantity = quantity;
            this.UnitPrice = unitPrice;
        }
        
        //Para levantar los datos
        public SubProductForTransaction(string id, SubProduct subProduct, BasicTransaction transaction, string quantity, string unitPrice, string creationDate, string modificationDate, string status)
        {
            this.Id = new Guid(id);
            this.SubProduct = subProduct;
            this.Transaction = transaction;
            this.Quantity = Convert.ToInt32(quantity);
            this.UnitPrice = Convert.ToDecimal(unitPrice.Replace('.', CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));
            this.CreationDate = DateTime.ParseExact(creationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.ModificationDate = DateTime.ParseExact(modificationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.Status = (Status)Convert.ToInt32(status);
        }
        
        public XElement GetXML()
        {
            return new XElement("SubProductForTransaction", new XElement("Id", this.Id), new XElement("SubProduct", this.SubProduct.Id), new XElement("Transaction", this.Transaction.Id), new XElement("Quantity", this.Quantity), new XElement("UnitPrice", this.UnitPrice),
                new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));
        }
    }
}
