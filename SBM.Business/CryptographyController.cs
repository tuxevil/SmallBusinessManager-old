using System;
using System.Collections.Generic;
using System.Xml;
using System.Security.Cryptography;
using System.Security.Cryptography.Xml;
using System.Xml.Linq;

namespace SBM.Business
{
    public class CryptographyController
    {
        CspParameters cspParams = new CspParameters();
        private XmlDocument xmlDoc;
        private RSACryptoServiceProvider rsaKey;
        private string path;
        private string fileName;
        private const string CryptExtention = "crypt";
        private const string KeyName = "rsaKey";

        public CryptographyController()
        {
            cspParams.KeyContainerName = "XML_ENC_RSA_KEY";
            rsaKey = new RSACryptoServiceProvider(cspParams);
        }

        public void LoadFile(string path, string fileName)
        {
            this.path = path;
            this.fileName = fileName;
            // Create an XmlDocument object.
            xmlDoc = new XmlDocument();

            // Load an XML file into the XmlDocument object.
            try
            {
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.Load(this.path + this.fileName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Create a new RSA key and save it in the container.  This key will encrypt
            // a symmetric key, which will then be encryped in the XML document.
            rsaKey = new RSACryptoServiceProvider(cspParams);
        }

        public void LoadData(string path, string fileName, XDocument xDocument)
        {
            this.path = path;
            this.fileName = fileName;
            // Create an XmlDocument object.
            xmlDoc = new XmlDocument();

            // Load an XML file into the XmlDocument object.
            try
            {
                xmlDoc = xDocument.ToXmlDocument();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // Create a new RSA key and save it in the container.  This key will encrypt
            // a symmetric key, which will then be encryped in the XML document.
            rsaKey = new RSACryptoServiceProvider(cspParams);
        }

        public void Close()
        {
            rsaKey.Clear();
        }
        
        public void Encrypt(string ElementToEncrypt)
        {
            // Check the arguments.
            if (xmlDoc == null)
                throw new ArgumentNullException("Doc");
            if (ElementToEncrypt == null)
                throw new ArgumentNullException("ElementToEncrypt");
            if (rsaKey == null)
                throw new ArgumentNullException("Alg");

            RijndaelManaged sessionKey = null;

            try
            {
                //////////////////////////////////////////////////
                // Create a new instance of the EncryptedXml class
                // and use it to encrypt the XmlElement with the
                // a new random symmetric key.
                //////////////////////////////////////////////////

                // Create a 256 bit Rijndael key.
                sessionKey = new RijndaelManaged();
                sessionKey.KeySize = 256;

                EncryptedXml eXml = new EncryptedXml();

                for (int index = 0; xmlDoc.GetElementsByTagName(ElementToEncrypt).Count > 0; index++)
                {
                    XmlElement elementToEncrypt = xmlDoc.GetElementsByTagName(ElementToEncrypt)[0] as XmlElement;

                    // Throw an XmlException if the element was not found.
                    if (elementToEncrypt == null)
                        throw new XmlException("The specified element was not found");

                    byte[] encryptedElement = eXml.EncryptData(elementToEncrypt, sessionKey, false);
                    ////////////////////////////////////////////////
                    // Construct an EncryptedData object and populate
                    // it with the desired encryption information.
                    ////////////////////////////////////////////////

                    EncryptedData edElement = new EncryptedData();
                    edElement.Type = EncryptedXml.XmlEncElementUrl;
                    edElement.Id = "Encrypted" + ElementToEncrypt + index;
                    // Create an EncryptionMethod element so that the
                    // receiver knows which algorithm to use for decryption.

                    edElement.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncAES256Url);
                    // Encrypt the session key and add it to an EncryptedKey element.
                    EncryptedKey ek = new EncryptedKey();

                    byte[] encryptedKey = EncryptedXml.EncryptKey(sessionKey.Key, rsaKey, false);

                    ek.CipherData = new CipherData(encryptedKey);

                    ek.EncryptionMethod = new EncryptionMethod(EncryptedXml.XmlEncRSA15Url);

                    // Create a new DataReference element
                    // for the KeyInfo element.  This optional
                    // element specifies which EncryptedData
                    // uses this key.  An XML document can have
                    // multiple EncryptedData elements that use
                    // different keys.
                    DataReference dRef = new DataReference();

                    // Specify the EncryptedData URI.
                    dRef.Uri = "#" + "Encrypted" + ElementToEncrypt + index;

                    // Add the DataReference to the EncryptedKey.
                    ek.AddReference(dRef);
                    // Add the encrypted key to the
                    // EncryptedData object.

                    edElement.KeyInfo.AddClause(new KeyInfoEncryptedKey(ek));
                    // Set the KeyInfo element to specify the
                    // name of the RSA key.


                    // Create a new KeyInfoName element.
                    KeyInfoName kin = new KeyInfoName();

                    // Specify a name for the key.
                    kin.Value = KeyName;

                    // Add the KeyInfoName element to the
                    // EncryptedKey object.
                    ek.KeyInfo.AddClause(kin);
                    // Add the encrypted element data to the
                    // EncryptedData object.
                    edElement.CipherData.CipherValue = encryptedElement;
                    ////////////////////////////////////////////////////
                    // Replace the element from the original XmlDocument
                    // object with the EncryptedData element.
                    ////////////////////////////////////////////////////
                    EncryptedXml.ReplaceElement(elementToEncrypt, edElement, false);
                }
                // Save the XML document.
                xmlDoc.Save(string.Format("{0}{1}{2}", path, CryptExtention, fileName));
            }
            catch (Exception e)
            {
                // re-throw the exception.
                throw e;
            }
            finally
            {
                if (sessionKey != null)
                {
                    sessionKey.Clear();
                }

            }

        }

        public XDocument Decrypt()
        {
            EncryptedXml exml = new EncryptedXml(xmlDoc);
            exml.AddKeyNameMapping(KeyName, rsaKey);
            exml.DecryptDocument();
            return xmlDoc.ToXDocument();
        }
    }

    public static class DocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
}