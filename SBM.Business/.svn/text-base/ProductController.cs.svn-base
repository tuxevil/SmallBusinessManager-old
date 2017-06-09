using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Business.Interfaces;
using SBM.Core;

namespace SBM.Business
{
    public class ProductController : BaseController, IController<Product, Guid>
    {
        public ProductController()
        {
            this.className = "Product";
            LoadFile();
        }
        
        public Product Create(string name, string description, decimal price, decimal finalPrice)
        {
            Product p = new Product(name, description, price, finalPrice);
            documentXML.Element(className + "s").Add(p.GetXML());
            Save();
            return p;
        }

        private void Modify(Guid id, string name, string description, decimal price, decimal finalPrice, int stockQuantity, Status status)
        {
            XElement c = GetXElement(id);

            c.Element("Name").Value = name;
            c.Element("Description").Value = description;
            c.Element("Price").Value = price.ToString();
            c.Element("FinalPrice").Value = finalPrice.ToString();
            c.Element("StockQuantity").Value = stockQuantity.ToString();
            c.Element("ModificationDate").Value = DateTime.Now.ToString("yyyyMMdd");
            c.Element("Status").Value = ((int)status).ToString();

            Save();
        }

        public void SaveOrUpdate(Product o)
        {
            Modify(o.Id, o.Name, o.Description, o.Price, o.FinalPrice, o.StockQuantity, o.Status);
        }

        public void Erase(Product o)
        {
            Modify(o.Id, o.Name, o.Description, o.Price, o.FinalPrice, o.StockQuantity, Status.Deleted);
        }

        public List<Product> GetAll()
        {
            return GetFromItem(GetAllGeneric());
        }

        public Product Get(Guid id)
        {
            return GetFromItem(GetGeneric(id));
        }

        public List<Product> Get(string search)
        {
            LoadFile();
            List<Product> result = new List<Product>(from item in documentXML.Descendants(className)
                                      where item.Element("Name").Value.ToLower().Contains(search.ToLower()) ||
                                      item.Element("Description").Value.ToLower().Contains(search.ToLower())
                                      select GetFromItem(item));
            result.Sort(delegate(Product p1, Product p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return result;
        }

        public Product GetFromItem(XElement item)
        {
            return new Product(item.Element("Id").Value,
                                item.Element("Name").Value,
                                item.Element("StockQuantity").Value,
                                item.Element("Description").Value,
                                item.Element("Price").Value,
                                item.Element("FinalPrice").Value,
                                item.Element("CreationDate").Value,
                                item.Element("ModificationDate").Value,
                                item.Element("Status").Value);
        }

        public List<Product> GetFromItem(List<XElement> items)
        {
            List<Product> lst = new List<Product>();
            foreach (XElement item in items)
                lst.Add(GetFromItem(item));
            lst.Sort(delegate(Product p1, Product p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return lst;
        }
    }
}
