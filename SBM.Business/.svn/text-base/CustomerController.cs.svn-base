using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Business.Interfaces;
using SBM.Core;

namespace SBM.Business
{
    public class CustomerController : BaseController, IController<Customer, Guid>
    {
        public CustomerController()
        {
            this.className = "Customer";
            LoadFile();
        }

        public Customer Create(string name, string lastName, string nickName, string phone, string address, string email)
        {
            Customer c = new Customer(name, lastName, nickName, phone, address,email);
            documentXML.Element(className + "s").Add(c.GetXML());
            Save();
            return c;
        }

        private void Modify(Guid id, string name, string lastName, string nickName, string phone, string address, string email, Status status)
        {
            XElement c = GetXElement(id);

            c.Element("Name").Value = name;
            c.Element("LastName").Value = lastName;
            c.Element("NickName").Value = nickName;
            c.Element("Phone").Value = phone;
            c.Element("Address").Value = address;
            c.Element("Email").Value = email;
            c.Element("ModificationDate").Value = DateTime.Now.ToString("yyyyMMdd");
            c.Element("Status").Value = ((int)status).ToString();

            Save();
        }

        public List<Customer> GetAll()
        {
            return GetFromItem(GetAllGeneric());
        }

        public List<Customer> GetAllActive()
        {
            return GetFromItem(GetAllGenericActive());
        }

        public Customer Get(Guid id)
        {
            return GetFromItem(GetGeneric(id));
        }

        public Customer GetActive(Guid id)
        {
            return GetFromItem(GetGenericActive(id));
        }

        public List<Customer> Get(string search)
        {
            LoadFile();
            List<Customer> result = new List<Customer>(from item in documentXML.Descendants(className)
                    where (item.Element("Name").Value.ToLower().Contains(search.ToLower()) ||
                    item.Element("LastName").Value.ToLower().Contains(search.ToLower()) ||
                    item.Element("NickName").Value.ToLower().Contains(search.ToLower())) && 
                    item.Element("Status").Value.Equals(((int)Status.Active).ToString())
                    select GetFromItem(item));
            result.Sort(delegate(Customer p1, Customer p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return result;
        }

        public Customer GetFromItem(XElement item)
        {
            return new Customer(item.Element("Id").Value,
                                item.Element("Name").Value,
                                item.Element("LastName").Value,
                                item.Element("NickName").Value,
                                item.Element("Phone").Value,
                                item.Element("Address").Value,
                                item.Element("Email").Value,
                                item.Element("CreationDate").Value,
                                item.Element("ModificationDate").Value,
                                item.Element("Status").Value);
        }

        public List<Customer> GetFromItem(List<XElement> items)
        {
            List<Customer> lst = new List<Customer>();
            foreach (XElement item in items)
                lst.Add(GetFromItem(item));
            lst.Sort(delegate(Customer p1, Customer p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return lst;
        }

        public void SaveOrUpdate(Customer o)
        {
            Modify(o.Id, o.Name, o.LastName, o.NickName, o.Phone, o.Address, o.Email, o.Status);
        }

        public void Erase(Customer o)
        {
            Modify(o.Id, o.Name, o.LastName, o.NickName, o.Phone, o.Address, o.Email, Status.Deleted);
        }
    }
}
