using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Business.Interfaces;
using SBM.Core;

namespace SBM.Business
{
    public class PartByProviderController : BaseController, IController<PartByProvider, Guid>
    {
        private PartController partController;
        private ProviderController providerController;

        public PartByProviderController()
        {
            this.className = "PartByProvider";
            LoadFile();
            partController = new PartController();
            providerController = new ProviderController();
        }

        public PartByProvider Create(Part part, Provider provider, decimal price)
        {
            PartByProvider pbp = new PartByProvider(part, provider, price);
            documentXML.Element(className + "s").Add(pbp.GetXML());
            Save();
            return pbp;
        }

        private void Modify(Guid id, Part part, Provider provider, decimal price, Status status)
        {
            XElement c = GetXElement(id);

            c.Element("Part").Value = part.Id.ToString();
            c.Element("Provider").Value = provider.Id.ToString();
            c.Element("Price").Value = price.ToString();
            c.Element("ModificationDate").Value = DateTime.Now.ToString("yyyyMMdd");
            c.Element("Status").Value = ((int)status).ToString();

            Save();
        }

        public List<PartByProvider> GetAll()
        {
            return GetFromItem(GetAllGeneric());
        }

        public PartByProvider Get(Guid id)
        {
            return GetFromItem(GetGeneric(id));
        }

        public List<PartByProvider> Get(string search)
        {
            throw new NotImplementedException();
        }

        public PartByProvider GetFromItem(XElement item)
        {
            return new PartByProvider(item.Element("Id").Value,
                                partController.Get(new Guid(item.Element("Part").Value)),
                                providerController.Get(new Guid(item.Element("Provider").Value)),
                                item.Element("Price").Value,
                                item.Element("CreationDate").Value,
                                item.Element("ModificationDate").Value,
                                item.Element("Status").Value);
        }

        public List<PartByProvider> GetFromItem(List<XElement> items)
        {
            List<PartByProvider> lst = new List<PartByProvider>();
            foreach (XElement item in items)
                lst.Add(GetFromItem(item));
            lst.Sort(delegate(PartByProvider p1, PartByProvider p2)
            {
                return p1.Part.Name.CompareTo(p2.Part.Name);
            });
            return lst;
        }

        public void SaveOrUpdate(PartByProvider o)
        {
            Modify(o.Id, o.Part, o.Provider, o.Price, o.Status);
        }

        public void Erase(PartByProvider o)
        {
            Modify(o.Id, o.Part, o.Provider, o.Price, Status.Deleted);
        }

        public void EraseFor(Part p)
        {
            List<PartByProvider> partByProviders = GetFor(p);

            foreach (PartByProvider partByProvider in partByProviders)
                Erase(partByProvider);
        }

        public List<PartByProvider> GetFor(Part p)
        {
            return new List<PartByProvider>(from item in documentXML.Descendants(className)
                                                                           where item.Element("Status").Value.Equals(((int)Status.Active).ToString()) &&
                                                                           item.Element("Part").Value.Equals(p.Id.ToString())
                                                                           select
                                                                               GetFromItem(item));
        }
    }
}
