using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class Sale : BasicTransaction
    {
        public Quote Quote { get; set;}
        public DateTime SaleDate { get; set; }

        public string CustomerName
        {
            get { return this.Customer.Name + " \"" + this.Customer.NickName + "\" " + this.Customer.LastName; }
        }

        //Para crear nuevos
        public Sale(Customer customer)
        {
            this.Customer = customer;
            this.Type = TransactionType.Sale;
            customer.Sales.Add(this);
        }

        public Sale(Quote quote)
        {
            this.Customer = quote.Customer;
            this.SubProductsForTransactions = quote.SubProductsForTransactions;
            this.Type = TransactionType.Sale;
            this.Customer.Sales.Add(this);
            this.Quote = quote;
            Confirm();
        }

        //Para levantar los datos
        public Sale(string id, Customer customer, Quote quote, string total, string type, string locked, string saleDate, string creationDate, string modificationDate, string status)
        {
            this.Id = new Guid(id);
            this.Customer = customer;
            this.Quote = quote;
            this.Total = Convert.ToDecimal(total.Replace('.', CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0]));
            this.Type = (TransactionType)Convert.ToInt32(type);
            if(locked.ToLower() == "true")
                this.Lock();
            this.SaleDate = DateTime.ParseExact(saleDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.CreationDate = DateTime.ParseExact(creationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.ModificationDate = DateTime.ParseExact(modificationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.Status = (Status)Convert.ToInt32(status);
        }

        public void Confirm()
        {
            this.SaleDate = DateTime.Now;
            this.Lock();
        }
        
        public XElement GetXML()
        {
            XElement element = new XElement("Sale", new XElement("Id", this.Id), new XElement("Customer", this.Customer.Id), new XElement("SubProductsForTransactions"), new XElement("Quote"),
                new XElement("Total", this.Total), new XElement("Type", (int)this.Type), new XElement("Locked", this.Locked),
                new XElement("SaleDate", this.SaleDate.ToString("yyyyMMdd")), new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));

            if (this.Quote != null)
                element.Element("Quote").Value = this.Quote.Id.ToString();

            return element;
        }
    }
}
