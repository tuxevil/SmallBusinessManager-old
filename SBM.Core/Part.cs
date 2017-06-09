using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class Part : BasicInfo
    {
        public decimal AveragePrice { get; set; }
        public List<PartByProvider> PartByProviders { get; set; }

        //Para crear nuevos
        public Part(string name, decimal price)
        {
            this.Name = name;
            this.StockQuantity = 0;
            this.AveragePrice = price;
            this.PartByProviders = new List<PartByProvider>();
        }
        
        //Para levantar los datos
        public Part(string id, string name, string stockQuantity, string averagePrice, string creationDate, string modificationDate, string status)
        {
            this.Id = new Guid(id);
            this.Name = name;
            this.StockQuantity = Convert.ToInt32(stockQuantity);
            this.AveragePrice = Convert.ToDecimal(averagePrice.Replace('.', CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));
            this.CreationDate = DateTime.ParseExact(creationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.ModificationDate = DateTime.ParseExact(modificationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.Status = (Status)Convert.ToInt32(status);
            this.PartByProviders = new List<PartByProvider>();
        }

        public XElement GetXML()
        {
            return new XElement("Part", new XElement("Id", this.Id), new XElement("Name", this.Name), new XElement("StockQuantity", this.StockQuantity), new XElement("AveragePrice", this.AveragePrice), 
                new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));
        }
    }
}
