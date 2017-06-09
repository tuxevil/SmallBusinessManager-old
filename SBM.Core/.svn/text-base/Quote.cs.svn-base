using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class Quote : BasicTransaction
    {
        public DateTime ValidTo { get; set;}
        public bool Selled { get; set; }

        public string CustomerName
        {
            get { return this.Customer.Name + " \"" + this.Customer.NickName + "\" " + this.Customer.LastName; }
        }

        //Para crear nuevos
        public Quote(Customer customer, DateTime validTo)
        {
            this.Customer = customer;
            this.ValidTo = validTo;
            this.Type = TransactionType.Quote;
            customer.Quotes.Add(this);
        }
        
        //Para levantar los datos
        public Quote(string id, Customer customer, string total, string type, string locked, string validTo, string selled, string creationDate, string modificationDate, string status)
        {
            this.Id = new Guid(id);
            this.Customer = customer;
            this.Total = Convert.ToDecimal(total.Replace('.', CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));
            this.Type = (TransactionType)Convert.ToInt32(type);
            if(locked.ToLower() == "true")
                this.Lock();
            if (selled.ToLower() == "true")
                this.Selled = true;
            this.ValidTo = DateTime.ParseExact(validTo, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.CreationDate = DateTime.ParseExact(creationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.ModificationDate = DateTime.ParseExact(modificationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.Status = (Status)Convert.ToInt32(status);
        }

        public XElement GetXML()
        {
            return new XElement("Quote", new XElement("Id", this.Id), new XElement("Customer", this.Customer.Id), new XElement("SubProductsForTransactions"),
                new XElement("Total", this.Total), new XElement("Type", (int)this.Type), new XElement("Locked", this.Locked),
                new XElement("ValidTo", this.ValidTo.ToString("yyyyMMdd")), new XElement("Selled", this.Selled), new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));
        }
    }
}
