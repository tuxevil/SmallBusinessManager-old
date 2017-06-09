using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class Provider : BasicEntity
    {
        public BasicEntity Contact { get; set; }
        public List<PartByProvider> PartByProviders { get; set; }

        //Para crear nuevos
        public Provider(string name, string phone, string address, string email, BasicEntity contact)
        {
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.Email = email;
            this.Contact = contact;
        }

        //Para levantar los datos
        public Provider(string id, string name, string phone, string address, string email, BasicEntity contact, string creationDate, string modificationDate, string status)
        {
            this.Id = new Guid(id);
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.Email = email;
            if(!string.IsNullOrEmpty(creationDate))
                this.CreationDate = DateTime.ParseExact(creationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            if (!string.IsNullOrEmpty(modificationDate))
                this.ModificationDate = DateTime.ParseExact(modificationDate, "yyyyMMdd", CultureInfo.InvariantCulture);
            this.Status = (Status) Convert.ToInt32(status);
            this.Contact = contact;
        }

        public XElement GetXML()
        {
            return new XElement("Provider", new XElement("Id", this.Id), new XElement("Name", this.Name), new XElement("Phone", this.Phone), new XElement("Address", this.Address), new XElement("Email", this.Email), Contact.GetXML(),
                new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));
        }
    }
}
