using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class SubProduct : BasicInfo
    {
        private Product product;
        List<Part> Parts { get; set; }

        public Product Product
        {
            get { return product; }
        }

        //Para crear nuevos
        public SubProduct(Product product, string name)
        {
            this.product = product;
            this.Name = name;
            this.StockQuantity = 0;
        }
        
        //Para levantar los datos
        public SubProduct(string id, Product product, string name, string stockQuantity, string creationDate, string modificationDate, string status)
        {
            this.Id = new Guid(id);
            this.Name = name;
            this.StockQuantity = Convert.ToInt32(stockQuantity);
            this.product = product;
            this.CreationDate = DateTime.ParseExact(creationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.ModificationDate = DateTime.ParseExact(modificationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.Status = (Status)Convert.ToInt32(status);
        }

        public XElement GetXML()
        {
            return new XElement("SubProduct", new XElement("Id", this.Id), new XElement("Name", this.Name), new XElement("StockQuantity", this.StockQuantity), new XElement("Product", this.Product.Id),
                new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));
        }
    }
}
