using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Business.Interfaces;
using SBM.Core;

namespace SBM.Business
{
    public class SubProductController : BaseController, IController<SubProduct, Guid>
    {
        private ProductController productController;

        public SubProductController()
        {
            this.className = "SubProduct";
            LoadFile();
            this.productController = new ProductController();
        }

        public SubProduct Create(Product product, string name)
        {
            SubProduct sp = new SubProduct(product, name);
            documentXML.Element(className + "s").Add(sp.GetXML());
            Save();

            return sp;
        }

        private void Modify(Guid id, string name, int stockQuantity, Status status)
        {
            XElement c = GetXElement(id);

            c.Element("Name").Value = name;
            c.Element("StockQuantity").Value = stockQuantity.ToString();
            c.Element("ModificationDate").Value = DateTime.Now.ToString("yyyyMMdd");
            c.Element("Status").Value = ((int)status).ToString();

            Save();
        }

        public void IncreaseStock(SubProduct subProduct, int stockIncrease)
        {
            subProduct.IncreaseStock(stockIncrease);
            subProduct.Product.IncreaseStock(stockIncrease);
            SaveOrUpdate(subProduct);
            productController.SaveOrUpdate(subProduct.Product);
        }

        public void DecreaseStock(SubProduct subProduct, int stockDecrease)
        {
            subProduct.DecreaseStock(stockDecrease);
            subProduct.Product.DecreaseStock(stockDecrease);
            SaveOrUpdate(subProduct);
            productController.SaveOrUpdate(subProduct.Product);
        }
        
        public List<SubProduct> GetAllFor(Product product)
        {
            LoadFile();
            List<SubProduct> result = new List<SubProduct>(from item in documentXML.Descendants(className)
                                        where item.Element("Product").Value.Equals(product.Id.ToString())
                                        select
                                            GetFromItem(item));
            result.Sort(delegate(SubProduct p1, SubProduct p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return result;
        }

        public List<SubProduct> GetAll()
        {
            return GetFromItem(GetAllGeneric());
        }

        public SubProduct Get(Guid id)
        {
            return GetFromItem(GetGeneric(id));
        }

        public List<SubProduct> Get(string search)
        {
            LoadFile();
            List<SubProduct> result = new List<SubProduct>(from item in documentXML.Descendants(className)
                                     where item.Element("Name").Value.ToLower().Contains(search.ToLower())
                                     select GetFromItem(item));
            result.Sort(delegate(SubProduct p1, SubProduct p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return result;
        }

        public SubProduct GetFromItem(XElement item)
        {
            return new SubProduct(item.Element("Id").Value,
                productController.Get(new Guid(item.Element("Product").Value)),
                                item.Element("Name").Value,
                                item.Element("StockQuantity").Value,
                                item.Element("CreationDate").Value,
                                item.Element("ModificationDate").Value,
                                item.Element("Status").Value);
        }

        public List<SubProduct> GetFromItem(List<XElement> items)
        {
            List<SubProduct> lst = new List<SubProduct>();
            foreach (XElement item in items)
                lst.Add(GetFromItem(item));
            lst.Sort(delegate(SubProduct p1, SubProduct p2)
            {
                return p1.Name.CompareTo(p2.Name);
            });
            return lst;
        }

        public void SaveOrUpdate(SubProduct o)
        {
            Modify(o.Id, o.Name, o.StockQuantity, o.Status);
        }

        public void Erase(SubProduct o)
        {
            Modify(o.Id, o.Name, o.StockQuantity, Status.Deleted);
        }
    }
}
