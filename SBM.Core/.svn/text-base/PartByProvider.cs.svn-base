using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class PartByProvider : Entity
    {
        public Part Part { get; set; }
        public Provider Provider { get; set; }
        public decimal Price { get; set; }

        //Para crear nuevos
        public PartByProvider(Part part, Provider provider, decimal price)
        {
            this.Part = part;
            this.Provider = provider;
            this.Price = price;
        }
        
        //Para levantar los datos
        public PartByProvider(string id, Part part, Provider provider, string price, string creationDate, string modificationDate, string status)
        {
            this.Id = new Guid(id);
            this.Part = part;
            this.Provider = provider;
            this.Price = Convert.ToDecimal(price.Replace('.', CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));
            this.CreationDate = DateTime.ParseExact(creationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.ModificationDate = DateTime.ParseExact(modificationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.Status = (Status)Convert.ToInt32(status);
        }

        public XElement GetXML()
        {
            return new XElement("PartByProvider", new XElement("Id", this.Id), new XElement("Part", this.Part.Id), new XElement("Provider", this.Provider.Id), new XElement("Price", this.Price), 
                new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));
        }
    }
}
