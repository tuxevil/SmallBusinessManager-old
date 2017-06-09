using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class PartForSubProduct : Entity
    {
        public Part Part { get; set; }
        public SubProduct SubProduct { get; set; }
        public decimal Quantity { get; set; }

        public string PartName
        {
            get { return Part.Name; }
        }
        public decimal CostForProduct
        {
            get { return Part.AveragePrice*Quantity; }
        }

        //Para crear nuevos
        public PartForSubProduct(Part part, SubProduct subProduct, decimal quantity)
        {
            this.Part = part;
            this.SubProduct = subProduct;
            this.Quantity = quantity;
        }
        
        //Para levantar los datos
        public PartForSubProduct(string id, Part part, SubProduct subProduct, string quantity, string creationDate, string modificationDate, string status)
        {
            this.Id = new Guid(id);
            this.Part = part;
            this.SubProduct = subProduct;
            this.Quantity = Convert.ToDecimal(quantity.Replace('.', CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));
            this.CreationDate = DateTime.ParseExact(creationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.ModificationDate = DateTime.ParseExact(modificationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.Status = (Status)Convert.ToInt32(status);
        }

        public XElement GetXML()
        {
            return new XElement("PartForSubProduct", new XElement("Id", this.Id), new XElement("Part", this.Part.Id), new XElement("SubProduct", this.SubProduct.Id), new XElement("Quantity", this.Quantity), 
                new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));
        }
    }
}
