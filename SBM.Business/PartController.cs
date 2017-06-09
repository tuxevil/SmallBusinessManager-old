using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Business.Interfaces;
using SBM.Core;

namespace SBM.Business
{
    public class PartController : BaseController, IController<Part, Guid>
    {
        public PartController()
        {
            this.className = "Part";
            LoadFile();
        }

        public Part Create(string name, decimal averagePrice)
        {
            Part p = new Part(name, averagePrice);
            documentXML.Element(className + "s").Add(p.GetXML());
            Save();
            return p;
        }

        private void Modify(Guid id, string name, decimal averagePrice, int stockQuantity, Status status)
        {
            XElement c = GetXElement(id);

            c.Element("Name").Value = name;
            c.Element("AveragePrice").Value = averagePrice.ToString();
            c.Element("StockQuantity").Value = stockQuantity.ToString();
            c.Element("ModificationDate").Value = DateTime.Now.ToString("yyyyMMdd");
            c.Element("Status").Value = ((int)status).ToString();

            Save();
        }
        
        public List<Part> GetAll()
        {
            return GetFromItem(GetAllGeneric());
        }

        public Part Get(Guid id)
        {
            return GetFromItem(GetGeneric(id));
        }

        public List<Part> Get(string search)
        {
            LoadFile();
            List<Part> result = new List<Part>(from item in documentXML.Descendants(className)
                                     where item.Element("Name").Value.ToLower().Contains(search.ToLower())
                                     select GetFromItem(item));
            result.Sort(delegate(Part p1, Part p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return result;
        }

        public Part GetFromItem(XElement item)
        {
            return new Part(item.Element("Id").Value,
                                item.Element("Name").Value,
                                item.Element("StockQuantity").Value,
                                item.Element("AveragePrice").Value,
                                item.Element("CreationDate").Value,
                                item.Element("ModificationDate").Value,
                                item.Element("Status").Value);
        }

        public List<Part> GetFromItem(List<XElement> items)
        {
            List<Part> lst = new List<Part>();
            foreach (XElement item in items)
                lst.Add(GetFromItem(item));
            lst.Sort(delegate(Part p1, Part p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return lst;
        }

        public void SaveOrUpdate(Part o)
        {
            Modify(o.Id, o.Name, o.AveragePrice, o.StockQuantity, o.Status);
        }

        public void Erase(Part o)
        {
            Modify(o.Id, o.Name, o.AveragePrice, o.StockQuantity, Status.Deleted);
        }

        public void IncreaseStock(Part part, int stockIncrease)
        {
            part.IncreaseStock(stockIncrease);
            SaveOrUpdate(part);
        }

        public void DecreaseStock(Part part, int stockDecrease)
        {
            part.DecreaseStock(stockDecrease);
            SaveOrUpdate(part);
        }
    }
}
