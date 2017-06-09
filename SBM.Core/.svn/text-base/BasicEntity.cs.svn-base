using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace SBM.Core
{
    public class BasicEntity : Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public BasicEntity() {}

        //Para crear "semi" nuevos
        public BasicEntity(string name, string phone, string address, string email)
        {
            this.Name = name;
            this.Phone = phone;
            this.Address = address;
            this.Email = email;
            this.Status = Core.Status.Active;
        }

        //Para levantar los datos
        public BasicEntity(string id, string name, string phone, string address, string email, string creationDate, string modificationDate, string status)
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
        }

        public XElement GetXML()
        {
            return new XElement("Contact", new XElement("Id", this.Id), new XElement("Name", this.Name), new XElement("Phone", this.Phone), new XElement("Address", this.Address), new XElement("Email", this.Email),
                new XElement("CreationDate", this.CreationDate.ToString("yyyyMMdd")), new XElement("ModificationDate", this.ModificationDate.ToString("yyyyMMdd")), new XElement("Status", (int)this.Status));
        }
    }
}
