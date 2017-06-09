using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Business.Interfaces;
using SBM.Core;

namespace SBM.Business
{
    public class ProviderController: BaseController , IController<Provider, Guid>
    {
        public ProviderController()
        {
            this.className = "Provider";
            LoadFile();
        }

        public Provider Create(string name, string phone, string address, string email, BasicEntity contact)
        {
            Provider p = new Provider(name, phone, address, email, contact);
            documentXML.Element(className + "s").Add(p.GetXML());
            Save();
            return p;
        }

        private void Modify(Guid id, string name, string phone, string address, string email, XElement contact, Status status)
        {
            XElement c = GetXElement(id);

            c.Element("Name").Value = name;
            c.Element("Phone").Value = phone;
            c.Element("Address").Value = address;
            c.Element("Email").Value = email;
            c.Element("Contact").Remove();
            c.Add(contact);
            c.Element("ModificationDate").Value = DateTime.Now.ToString("yyyyMMdd");
            c.Element("Status").Value = ((int)status).ToString();

            Save();
        }

        public List<Provider> GetAll()
        {
            return GetFromItem(GetAllGeneric());
        }

        public Provider Get(Guid id)
        {
            return GetFromItem(GetGeneric(id));
        }

        public List<Provider> Get(string search)
        {
            LoadFile();
            List<Provider> result = new List<Provider>(from item in documentXML.Descendants(className)
                                      where item.Element("Name").Value.ToLower().Contains(search.ToLower()) ||
                                      item.Element("Contact").Element("Name").Value.ToLower().Contains(search.ToLower())
                                      select GetFromItem(item));
            result.Sort(delegate(Provider p1, Provider p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return result;
        }

        public Provider GetFromItem(XElement item)
        {
            return new Provider(item.Element("Id").Value,
                                item.Element("Name").Value,
                                item.Element("Phone").Value,
                                item.Element("Address").Value,
                                item.Element("Email").Value,
                                GetContactFromItem(item.Element("Contact")),
                                item.Element("CreationDate").Value,
                                item.Element("ModificationDate").Value,
                                item.Element("Status").Value);
        }

        private BasicEntity GetContactFromItem(XElement item)
        {
            return new BasicEntity(item.Element("Id").Value,
                                item.Element("Name").Value,
                                item.Element("Phone").Value,
                                item.Element("Address").Value,
                                item.Element("Email").Value,
                                item.Element("CreationDate").Value,
                                item.Element("ModificationDate").Value,
                                item.Element("Status").Value);
            
        }

        public List<Provider> GetFromItem(List<XElement> items)
        {
            List<Provider> lst = new List<Provider>();
            foreach (XElement item in items)
                lst.Add(GetFromItem(item));
            lst.Sort(delegate(Provider p1, Provider p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return lst;
        }

        public void SaveOrUpdate(Provider o)
        {
            Modify(o.Id, o.Name, o.Phone, o.Address, o.Email, o.Contact.GetXML(), o.Status);
        }

        public void Erase(Provider o)
        {
            Modify(o.Id, o.Name, o.Phone, o.Address, o.Email, o.Contact.GetXML(), Status.Deleted);
        }
    }
}
