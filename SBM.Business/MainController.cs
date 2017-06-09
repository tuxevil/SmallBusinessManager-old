using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;
using Microsoft.Win32;

namespace SBM.Business
{
    public class MainController
    {
        private string path;
        private string fileName = "stats.xml";
        public string dataFile;
        public XDocument documentXML;
        private CryptographyController cryptographyController;
        private const int trialDays = 60;
        private const int trialRuns = 60;

        public string License
        {
            get { return GetInfo().Element("Stat").Element("License").Value; }
            set
            {
                XElement x = GetInfo();
                x.Element("Stat").Element("License").Value = value;
                Encrypt();
            }
        }

        public DateTime InstalationDate
        {
            get { return DateTime.ParseExact(GetInfo().Element("Stat").Element("InstalationDate").Value, "yyyyMMdd", CultureInfo.InvariantCulture); }
            set
            {
                XElement x = GetInfo();
                x.Element("Stat").Element("InstalationDate").Value = value.ToString("yyyyMMdd");
                Encrypt();
            }
        }

        public int StartedTimes
        {
            get { return Convert.ToInt32(GetInfo().Element("Stat").Element("StartedTimes").Value); }
            set
            {
                XElement x = GetInfo();
                x.Element("Stat").Element("StartedTimes").Value = value.ToString();
                //x.Element("Stat").Add(new XElement("StartedTimes", 1));
                Encrypt();
            }
        }

        public DateTime LastDateOpened
        {
            get { return DateTime.ParseExact(GetInfo().Element("Stat").Element("LastDateOpened").Value, "yyyyMMdd", CultureInfo.InvariantCulture); }
            set
            {
                XElement x = GetInfo();
                //x.Element("Stat").Add(new XElement("LastDateOpened", DateTime.Today.ToString("yyyyMMdd")));
                x.Element("Stat").Element("LastDateOpened").Value = value.ToString("yyyyMMdd");
                Encrypt();
            }
        }

        public bool HasValidLicense
        {
            get { return GetVerificationCode() == this.License; }
        }

        public int DaysLeft
        {
            get
            {
                TimeSpan span = this.InstalationDate.AddDays(trialDays) - DateTime.Today;
                if(span.Days >= 0)
                    return span.Days;
                return -1;
            }
        }

        public int RunsLeft
        {
            get
            {
                if (trialRuns - StartedTimes >= 0)
                    return trialRuns - StartedTimes;
                return -1;
            }
        }

        public MainController()
        {
            this.cryptographyController = new CryptographyController();

#if DEBUG
            this.path = Environment.CurrentDirectory.Substring(0, Environment.CurrentDirectory.Length - 10) + "\\resources\\";
#else
            this.path = Environment.CurrentDirectory + "\\resources\\";
#endif
            LoadFile();
        }

        private XElement GetInfo()
        {
            LoadFile();
            try
            {
                return (from item in documentXML.Descendants("Stats")
                        select item).Single();
            }
            catch (Exception)
            {
                return null;
            }

        }

        private void LoadFile()
        {
            if (this.documentXML != null)
            {
                this.documentXML = null;
                GC.Collect();
            }
            this.documentXML = Decrypt();

            if(!this.documentXML.Element("Stats").HasElements)
            {
                this.documentXML.Element("Stats").Add(new XElement("Stat", new XElement("License"), new XElement("InstalationDate", DateTime.Today.ToString("yyyyMMdd")), new XElement("StartedTimes", 0), new XElement("LastDateOpened", DateTime.Today.ToString("yyyyMMdd"))));
                Encrypt();
            }
        }

        private void Encrypt()
        {
            cryptographyController.LoadData(path, fileName, documentXML);
            cryptographyController.Encrypt("Stat");
        }

        private XDocument Decrypt()
        {
            cryptographyController.LoadFile(path, "crypt" + fileName);
            return cryptographyController.Decrypt();
        }

        public string GetVerificationCode()
        {
            string ret = GetClientLicenseCode();

            Guid g = new Guid(ret);

            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(g.ToString());
            data = x.ComputeHash(data);
            ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }

        public string GetClientLicenseCode()
        {
            RegistryKey regKeyAppRoot = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Cryptography");
            string strWindowsState = (string)regKeyAppRoot.GetValue("MachineGuid");

            MD5CryptoServiceProvider x = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(strWindowsState);
            data = x.ComputeHash(data);
            string ret = "";
            for (int i = 0; i < data.Length; i++)
                ret += data[i].ToString("x2").ToLower();
            return ret;
        }
    }
}
