using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Business.Interfaces;
using SBM.Core;

namespace SBM.Business
{
    public class PartForSubProductController : BaseController, IController<PartForSubProduct, Guid>
    {
        private PartController partController;
        private SubProductController subProductController;

        public PartForSubProductController()
        {
            this.className = "PartForSubProduct";
            LoadFile();
            partController = new PartController();
            subProductController = new SubProductController();
        }

        public PartForSubProduct Create(Part part, SubProduct subProduct, decimal quantity)
        {
            PartForSubProduct pbsp = new PartForSubProduct(part, subProduct, quantity);
            documentXML.Element(className + "s").Add(pbsp.GetXML());
            Save();
            return pbsp;
        }

        private void Modify(Guid id, Part part, SubProduct subProduct, decimal quantity, Status status)
        {
            XElement c = GetXElement(id);

            c.Element("Part").Value = part.Id.ToString();
            c.Element("SubProduct").Value = subProduct.Id.ToString();
            c.Element("Quantity").Value = quantity.ToString();
            c.Element("ModificationDate").Value = DateTime.Now.ToString("yyyyMMdd");
            c.Element("Status").Value = ((int)status).ToString();

            Save();
        }
        
        public List<PartForSubProduct> GetAll()
        {
            return GetFromItem(GetAllGeneric());
        }

        public PartForSubProduct Get(Guid id)
        {
            return GetFromItem(GetGeneric(id));
        }

        public List<PartForSubProduct> Get(string search)
        {
            throw new NotImplementedException();
        }

        public PartForSubProduct GetFromItem(XElement item)
        {
            return new PartForSubProduct(item.Element("Id").Value,
                                partController.Get(new Guid(item.Element("Part").Value)),
                                subProductController.Get(new Guid(item.Element("SubProduct").Value)),
                                item.Element("Quantity").Value,
                                item.Element("CreationDate").Value,
                                item.Element("ModificationDate").Value,
                                item.Element("Status").Value);
        }

        public List<PartForSubProduct> GetFromItem(List<XElement> items)
        {
            List<PartForSubProduct> lst = new List<PartForSubProduct>();
            foreach (XElement item in items)
                lst.Add(GetFromItem(item));
            lst.Sort(delegate(PartForSubProduct p1, PartForSubProduct p2)
            {
                return p1.Part.Name.CompareTo(p2.Part.Name);
            });
            return lst;
        }

        public void SaveOrUpdate(PartForSubProduct o)
        {
            Modify(o.Id, o.Part, o.SubProduct, o.Quantity, o.Status);
        }

        public void Erase(PartForSubProduct o)
        {
            Modify(o.Id, o.Part, o.SubProduct, o.Quantity, Status.Deleted);
        }

        public void EraseFor(SubProduct sp)
        {
            List<PartForSubProduct> lst = GetFor(sp);

            foreach (PartForSubProduct item in lst)
                Erase(item);
        }

        public void EraseFor(Part p)
        {
            List<PartForSubProduct> lst = GetFor(p);

            foreach (PartForSubProduct item in lst)
                Erase(item);
        }

        public List<PartForSubProduct> GetFor(SubProduct sp)
        {
            return new List<PartForSubProduct>(from item in documentXML.Descendants(className)
                                            where item.Element("Status").Value.Equals(((int)Status.Active).ToString()) &&
                                            item.Element("SubProduct").Value.Equals(sp.Id.ToString())
                                            select
                                                GetFromItem(item));
        }

        public List<PartForSubProduct> GetFor(Part p)
        {
            return new List<PartForSubProduct>(from item in documentXML.Descendants(className)
                                               where item.Element("Status").Value.Equals(((int)Status.Active).ToString()) &&
                                               item.Element("Part").Value.Equals(p.Id.ToString())
                                               select
                                                   GetFromItem(item));
        }
    }
}
