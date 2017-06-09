using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Business.Interfaces;
using SBM.Core;

namespace SBM.Business
{
    public class SaleController : BaseController, IController<Sale, Guid>
    {
        private CustomerController customerController;
        private QuoteController quoteController;

        public SaleController()
        {
            this.className = "Sale";
            LoadFile();
            this.customerController = new CustomerController();
            quoteController = new QuoteController();
        }

        public Sale Create(Customer customer)
        {
            Sale s = new Sale(customer);
            documentXML.Element(className + "s").Add(s.GetXML());
            Save();
            return s;
        }

        public Sale Create(Quote quote)
        {
            Sale s = new Sale(quote);
            documentXML.Element(className + "s").Add(s.GetXML());
            Save();
            return s;
        }

        private void Modify(Guid id, Customer customer, Quote quote, DateTime saleDate, bool locked, decimal total, Status status)
        {
            XElement c = GetXElement(id);

            c.Element("Customer").Value = customer.Id.ToString();
            c.Element("Quote").Value = string.Empty;
            if(quote != null)
                c.Element("Quote").Value = quote.Id.ToString();
            c.Element("SaleDate").Value = saleDate.ToString("yyyyMMdd");
            c.Element("Locked").Value = locked.ToString();
            c.Element("Total").Value = total.ToString();
            c.Element("ModificationDate").Value = DateTime.Now.ToString("yyyyMMdd");
            c.Element("Status").Value = ((int)status).ToString();

            Save();
        }

        public List<Sale> GetAll()
        {
            return GetFromItem(GetAllGeneric());
        }

        public Sale Get(Guid id)
        {
            return GetFromItem(GetGeneric(id));
        }

        public List<Sale> Get(string userid)
        {
            LoadFile();
            return new List<Sale>(from item in documentXML.Descendants(className)
                                   where item.Element("Customer").Value.Equals(userid)
                                   select GetFromItem(item));
        }

        public Sale GetFromItem(XElement item)
        {
            if (item == null)
                return null;
            Sale s = new Sale(item.Element("Id").Value,
                             customerController.Get(new Guid(item.Element("Customer").Value)),
                             null,
                             item.Element("Total").Value,
                             item.Element("Type").Value,
                             item.Element("Locked").Value,
                             item.Element("SaleDate").Value,
                             item.Element("CreationDate").Value,
                             item.Element("ModificationDate").Value,
                             item.Element("Status").Value);
            if (!string.IsNullOrEmpty(item.Element("Quote").Value))
                s.Quote = quoteController.Get(new Guid(item.Element("Quote").Value));
            return s;
        }

        public List<Sale> GetFromItem(List<XElement> items)
        {
            List<Sale> lst = new List<Sale>();
            foreach (XElement item in items)
                lst.Add(GetFromItem(item));
            return lst;
        }

        public void SaveOrUpdate(Sale o)
        {
            Modify(o.Id, o.Customer, o.Quote, o.SaleDate, o.Locked, o.Total, o.Status);
        }

        public void Erase(Sale o)
        {
            Modify(o.Id, o.Customer, o.Quote, o.SaleDate, o.Locked, o.Total, Status.Deleted);
        }
    }
}
