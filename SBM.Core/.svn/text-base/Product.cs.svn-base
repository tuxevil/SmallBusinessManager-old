using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class Product : BasicInfo
    {
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal FinalPrice { get; set; }
        public List<SubProduct> SubProducts { get; set; }

        //Para crear nuevos
        public Product(string name, string description, decimal price, decimal finalPrice)
        {
            this.Name = name;
            this.StockQuantity = 0;
            this.Description = description;
            this.Price = price;
            this.FinalPrice = finalPrice;
            this.SubProducts = new List<SubProduct>();
        }
        
        //Para levantar los datos
        public Product(string id, string name, string stockQuantity, string description, string price, string finalPrice, string creationDate, string modificationDate, string status)
        {
            this.Id = new Guid(id);
            this.Name = name;
            this.StockQuantity = Convert.ToInt32(stockQuantity);
            this.Description = description;
            this.Price = Convert.ToDecimal(price.Replace('.', CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));
            this.FinalPrice = Convert.ToDecimal(finalPrice.Replace('.', CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));
            this.SubProducts = new List<SubProduct>();
            this.CreationDate = DateTime.ParseExact(creationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.ModificationDate = DateTime.ParseExact(modificationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.Status = (Status)Convert.ToInt32(status);
        }

        public XElement GetXML()
        {
            return new XElement("Product", new XElement("Id", this.Id), new XElement("Name", this.Name), new XElement("Description", this.Description), new XElement("StockQuantity", this.StockQuantity), new XElement("Price", this.Price), new XElement("FinalPrice", this.FinalPrice),
                new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));
        }
    }
}
