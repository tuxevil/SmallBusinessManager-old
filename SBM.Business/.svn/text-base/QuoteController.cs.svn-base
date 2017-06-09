using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Business.Interfaces;
using SBM.Core;

namespace SBM.Business
{
    public class QuoteController : BaseController , IController<Quote, Guid>
    {
        private CustomerController customerController;

        public QuoteController()
        {
            this.className = "Quote";
            LoadFile();
            this.customerController = new CustomerController();
        }

        public Quote Create(Customer customer, DateTime validTo)
        {
            Quote q = new Quote(customer, validTo);
            documentXML.Element(className + "s").Add(q.GetXML());
            Save();
            return q;
        }

        private void Modify(Guid id, Customer customer, DateTime validTo, decimal total, bool locked, bool selled, Status status)
        {
            XElement c = GetXElement(id);

            c.Element("Customer").Value = customer.Id.ToString();
            c.Element("ValidTo").Value = validTo.ToString("yyyyMMdd");
            c.Element("Locked").Value = locked.ToString();
            c.Element("Selled").Value = selled.ToString();
            c.Element("Total").Value = total.ToString();
            c.Element("ModificationDate").Value = DateTime.Now.ToString("yyyyMMdd");
            c.Element("Status").Value = ((int)status).ToString();

            Save();
        }

        public List<Quote> GetAll()
        {
            return GetFromItem(GetAllGeneric());
        }

        public List<Quote> GetAllActive()
        {
            return GetFromItem(GetAllGenericActive());
        }

        public Quote Get(Guid id)
        {
            return GetFromItem(GetGeneric(id));
        }

        public Quote GetActive(Guid id)
        {
            return GetFromItem(GetGenericActive(id));
        }

        public List<Quote> Get(string userid)
        {
            LoadFile();
            return new List<Quote>(from item in documentXML.Descendants(className)
                                      where item.Element("Customer").Value.Equals(userid)
                                      select GetFromItem(item));
        }
        
        public Quote GetFromItem(XElement item)
        {
            if(item == null)
                return null;
            return new Quote(item.Element("Id").Value,
                             customerController.Get(new Guid(item.Element("Customer").Value)),
                             item.Element("Total").Value,
                             item.Element("Type").Value,
                             item.Element("Locked").Value,
                             item.Element("ValidTo").Value,
                             item.Element("Selled").Value,
                             item.Element("CreationDate").Value,
                             item.Element("ModificationDate").Value,
                             item.Element("Status").Value);
        }

        public List<Quote> GetFromItem(List<XElement> items)
        {
            List<Quote> lst = new List<Quote>();
            foreach (XElement item in items)
                lst.Add(GetFromItem(item));
            return lst;
        }

        public void SaveOrUpdate(Quote o)
        {
            Modify(o.Id, o.Customer, o.ValidTo, o.Total, o.Locked, o.Selled, o.Status);
        }

        public void Erase(Quote o)
        {
            Modify(o.Id, o.Customer, o.ValidTo, o.Total, o.Locked, o.Selled, Status.Deleted);
        }
    }
}
