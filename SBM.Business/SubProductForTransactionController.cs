using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Business.Interfaces;
using SBM.Core;

namespace SBM.Business
{
    public class SubProductForTransactionController : BaseController, IController<SubProductForTransaction, Guid>
    {
        private SubProductController subProductController;
        private QuoteController quoteController;
        private SaleController saleController;

        public SubProductForTransactionController()
        {
            this.className = "SubProductForTransaction";
            LoadFile();
            subProductController = new SubProductController();
            quoteController = new QuoteController();
            saleController = new SaleController();
        }

        public SubProductForTransaction Create(SubProduct subProduct, BasicTransaction transaction)
        {
            SubProductForTransaction pbsp = new SubProductForTransaction(subProduct, transaction, 1, subProduct.Product.FinalPrice);
            documentXML.Element(className + "s").Add(pbsp.GetXML());
            Save();
            return pbsp;
        }

        private void Modify(Guid id, SubProduct subProduct, BasicTransaction transaction, int quantity, decimal unitPrice, Status status)
        {
            XElement c = GetXElement(id);

            c.Element("SubProduct").Value = subProduct.Id.ToString();
            c.Element("Transaction").Value = transaction.Id.ToString();
            c.Element("Quantity").Value = quantity.ToString();
            c.Element("UnitPrice").Value = unitPrice.ToString();
            c.Element("ModificationDate").Value = DateTime.Now.ToString("yyyyMMdd");
            c.Element("Status").Value = ((int)status).ToString();

            Save();
        }

        public List<SubProductForTransaction> GetAll()
        {
            return GetFromItem(GetAllGeneric());
        }

        public SubProductForTransaction Get(Guid id)
        {
            return GetFromItem(GetGeneric(id));
        }

        public List<SubProductForTransaction> Get(string search)
        {
            throw new NotImplementedException();
        }

        public SubProductForTransaction GetFromItem(XElement item)
        {
            SubProductForTransaction result = new SubProductForTransaction(item.Element("Id").Value,
                                subProductController.Get(new Guid(item.Element("SubProduct").Value)),
                                null,
                                item.Element("Quantity").Value,
                                item.Element("UnitPrice").Value,
                                item.Element("CreationDate").Value,
                                item.Element("ModificationDate").Value,
                                item.Element("Status").Value);

            BasicTransaction transaction = quoteController.Get(new Guid(item.Element("Transaction").Value));
            if (transaction == null)
                transaction = saleController.Get(new Guid(item.Element("Transaction").Value));
            result.Transaction = transaction;
            return result;
        }

        public List<SubProductForTransaction> GetFromItem(List<XElement> items)
        {
            LoadFile();
            List<SubProductForTransaction> lst = new List<SubProductForTransaction>();
            foreach (XElement item in items)
                lst.Add(GetFromItem(item));
            lst.Sort(delegate(SubProductForTransaction p1, SubProductForTransaction p2)
            {
                return p1.SubProduct.Product.Name.CompareTo(p2.SubProduct.Product.Name);
            });
            return lst;
        }

        public void SaveOrUpdate(SubProductForTransaction o)
        {
            Modify(o.Id, o.SubProduct, o.Transaction, o.Quantity, o.UnitPrice, o.Status);
        }

        public void Erase(SubProductForTransaction o)
        {
            Modify(o.Id, o.SubProduct, o.Transaction, o.Quantity, o.UnitPrice, Status.Deleted);
        }

        public void EraseFor(SubProduct sp)
        {
            List<SubProductForTransaction> lst = GetFor(sp);

            foreach (SubProductForTransaction item in lst)
                Erase(item);
        }

        public void EraseFor(BasicTransaction bt)
        {
            List<SubProductForTransaction> lst = GetFor(bt);

            foreach (SubProductForTransaction item in lst)
                Erase(item);
        }

        public List<SubProductForTransaction> GetFor(SubProduct sp)
        {
            LoadFile();
            return new List<SubProductForTransaction>(from item in documentXML.Descendants(className)
                                               where item.Element("Status").Value.Equals(((int)Status.Active).ToString()) &&
                                               item.Element("SubProduct").Value.Equals(sp.Id.ToString())
                                               select
                                                   GetFromItem(item));
        }

        public List<SubProductForTransaction> GetFor(BasicTransaction bt)
        {
            LoadFile();
            return new List<SubProductForTransaction>(from item in documentXML.Descendants(className)
                                               where item.Element("Status").Value.Equals(((int)Status.Active).ToString()) &&
                                               item.Element("Transaction").Value.Equals(bt.Id.ToString())
                                               select
                                                   GetFromItem(item));
        }
    }
}
