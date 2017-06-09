using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using SBM.Core;

namespace SBM.Business
{
    public class BaseController
    {
        private string path;
        private string fileName;
        public string dataFile;
        public XDocument documentXML;
        public string className;
        private CryptographyController cryptographyController;

        public BaseController()
        {
            this.cryptographyController = new CryptographyController();
        }

        public void LoadFile()
        {
            GetDataFilePath();
            if(this.documentXML != null)
            {
                this.documentXML = null;
                GC.Collect();
            }
            this.documentXML = Decrypt();
        }

        public void LoadDecryptedFile()
        {
            GetDataFilePath();
            if (this.documentXML != null)
            {
                this.documentXML = null;
                GC.Collect();
            }
            this.documentXML = XDocument.Load(dataFile);
        }

        public void SaveDecryptedFile()
        {
            LoadFile();
            XDocument backup = XDocument.Load(dataFile);
            backup.Element(className + "s").RemoveAll();

            foreach (XElement element in this.documentXML.Elements(className + "s"))
                backup.Element(className + "s").Add(element);

            backup.Save(dataFile);
        }
        

        public void Save()
        {
            Encrypt();
        }

        private void GetDataFilePath()
        {
#if DEBUG
            this.path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 10) + "\\resources\\";
#else
            this.path = Environment.CurrentDirectory + "\\resources\\";
#endif
            this.fileName = this.className.ToLower() + "s.xml";
            this.dataFile = path + "backup\\" + fileName;
        }

        public XElement GetGeneric(Guid id)
        {
            LoadFile();
            try
            {
                return (from item in documentXML.Descendants(className)
                        where item.Element("Id").Value.Equals(id.ToString())
                        select item).Single();
            }
            catch (Exception)
            {
                return null;
            }
            
        }

        public XElement GetGenericActive(Guid id)
        {
            LoadFile();
            return (from item in documentXML.Descendants(className)
                    where item.Element("Id").Value.Equals(id.ToString()) && item.Element("Status").Value.Equals(((int)Status.Active).ToString())
                    select item).Single();
        }

        public List<XElement> GetAllGeneric()
        {
            LoadFile();
            return new List<XElement>(from item in documentXML.Descendants(className)
                                      select
                                          item);
        }

        public List<XElement> GetAllGenericActive()
        {
            LoadFile();
            return new List<XElement>(from item in documentXML.Descendants(className)
                                      where item.Element("Status").Value.Equals(((int)Status.Active).ToString())
                                   select
                                       item);
        }

        public XElement GetXElement(Guid id)
        {
            return (from o in documentXML.Descendants(className)
                    where o.Element("Id").Value.Equals(id.ToString())
                    select o).Single();
        }

        private void Encrypt()
        {
            cryptographyController.LoadData(path, fileName, documentXML);
            cryptographyController.Encrypt(className);
        }

        private XDocument Decrypt()
        {
            GetDataFilePath();
            cryptographyController.LoadFile(path, "crypt" + fileName);
            return cryptographyController.Decrypt();
        }
    }
}
