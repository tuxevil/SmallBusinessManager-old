using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class Customer : BasicEntity
    {
        private List<Sale> sales = new List<Sale>();
        private List<Quote> quotes = new List<Quote>();

        public List<Sale> Sales
        {
            get { return sales; }
            set { sales = value; }
        }

        public List<Quote> Quotes
        {
            get { return quotes; }
            set { quotes = value; }
        }

        public string LastName { get; set; }
        public string NickName { get; set; }

        //Para crear nuevos
        public Customer(string name, string lastName, string nickName, string phone, string address, string email)
        {
            this.Name = name;
            this.LastName = lastName;
            this.NickName = nickName;
            this.Phone = phone;
            this.Address = address;
            this.Email = email;
        }

        //Para levantar los datos
        public Customer(string id, string name, string lastName, string nickName, string phone, string address, string email, string creationDate, string modificationDate, string status)
        {
            this.Id = new Guid(id);
            this.Name = name;
            this.LastName = lastName;
            this.NickName = nickName;
            this.Phone = phone;
            this.Address = address;
            this.Email = email;
            if(!string.IsNullOrEmpty(creationDate))
                this.CreationDate = DateTime.ParseExact(creationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(modificationDate))
                this.ModificationDate = DateTime.ParseExact(modificationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.Status = (Status) Convert.ToInt32(status);
        }

        public XElement GetXML()
        {
            return new XElement("Customer", new XElement("Id", this.Id), new XElement("Name", this.Name), new XElement("LastName", this.LastName), new XElement("NickName", this.NickName), new XElement("Phone", this.Phone),
                new XElement("Address", this.Address), new XElement("Email", this.Email), new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));
        }
    }
}
