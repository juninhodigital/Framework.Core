using System;
using System.Collections;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace Framework.Core
{
    /// <summary>
    /// Contains useful methods to user Client Certificates
    /// </summary>
    public sealed class Certificates
    {
        #region| Methods |

        /// <summary>
        /// Retuns an instance of the System.Security.Cryptography.X509Certificates.X509Certificate
        /// class using the name of a PKCS7 signed file and a password to access the certificate.
        /// </summary>
        /// <param name="fileName">The name of a PKCS7 signed file</param>
        /// <param name="password">The password required to access the X.509 certificate data</param>
        /// <returns>X509Certificate</returns>
        private X509Certificate GetCertificate(string fileName, string password)
        {
            #region | Certificate

            X509Certificate oCertificate = null;
            X509Store oStore = null;

            X509Certificate2Collection oCollection = null;
            X509Certificate2Collection oCollection1 = null;
            X509Certificate2Collection oCollection2 = null;
            X509Certificate2Collection oCertificateCollection = null;

            string SerialNumberCertificate = string.Empty;

            #endregion

            try
            {
                oCertificate = new X509Certificate(fileName, password);

                #region | CallBack

                //Confiar em todos os certificados
                ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);

                //validar certificate chamando uma função
                ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate(object sender2, X509Certificate certificate, X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors) { return true; });

                #endregion

                oStore = new X509Store(StoreName.My, StoreLocation.CurrentUser);
                oStore.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                oCollection = oStore.Certificates;
                oCollection1 = oCollection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);
                oCollection2 = oCollection1.Find(X509FindType.FindByKeyUsage, X509KeyUsageFlags.DigitalSignature, false);

                SerialNumberCertificate = oCertificate.GetSerialNumberString();

                if (!string.IsNullOrEmpty(SerialNumberCertificate))
                {
                    oCertificateCollection = oCollection2; //.Find(X509FindType.FindBySerialNumber, SerialNumberCertificate, false);

                    if (oCertificateCollection.Count == 0)
                    {
                        oCertificate.Reset();
                    }
                    else
                    {
                        oCertificate = oCertificateCollection[0];
                    }
                }

            }
            catch (Exception Erro)
            {
                oCertificate.Reset();
                throw Erro;
            }
            finally
            {
                oStore.Close();
                oStore = null;
                oCollection = null;
                oCollection1 = null;
                oCollection2 = null;
                oCertificateCollection = null;
            }

            return oCertificate;
        }

        /// <summary>
        /// Valida assinatura digital da NFE
        /// </summary>
        /// <param name="fileNFe"></param>
        /// <returns></returns>
        public static bool ValidarAssinaturaDigitalNFE(string fileNFe)
        {
            var oXML = new XmlDocument();

            oXML.PreserveWhitespace = true;
            oXML.Load(fileNFe);

            if (oXML.GetElementsByTagName("NFe").Count != 0)
            {
                // Pega a Tag "NFe" que contem assinatura digital
                var oNodeList = oXML.GetElementsByTagName("NFe");

                if (oNodeList.IsNotNull())
                {
                    string NFe = oNodeList[0].OuterXml.ToString();

                    //carregar o XML da NFe 

                    oXML = new XmlDocument();

                    oXML.PreserveWhitespace = true;
                    oXML.LoadXml(NFe);

                    //Carregar a assinatura
                    SignedXml signedXml = new SignedXml(oXML);
                    XmlNodeList nodeList = oXML.GetElementsByTagName("Signature");

                    signedXml.LoadXml((XmlElement)nodeList[0]);

                    //buscar o KeyInfo da assinatura
                    IEnumerator keyInfoItems = signedXml.KeyInfo.GetEnumerator();
                    keyInfoItems.MoveNext();

                    KeyInfoX509Data keyInfoX509 = (KeyInfoX509Data)keyInfoItems.Current;

                    //buscar o certificado do KeyInfo
                    X509Certificate2 keyInfoCert = (X509Certificate2)keyInfoX509.Certificates[0];

                    //Validar se assinatura é valida
                    return signedXml.CheckSignature(keyInfoCert.PublicKey.Key);
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Assinar o documento XML digitalmente
        /// </summary>
        /// <param name="FilePath"></param>
        /// <param name="pUri"></param>
        /// <param name="oX509Certificate2"></param>
        /// <returns>XML assinado</returns>
        public string AssinarDocumentoXML(string FilePath, string pUri, X509Certificate2 oX509Certificate2)
        {
            var XML = File.ReadAllText(FilePath);

            try
            {
                var oX509Cert = new X509Certificate2();

                var oX509Store = new X509Store("MY", StoreLocation.CurrentUser);

                oX509Store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

                var collection = oX509Store.Certificates;
                var collection1 = collection.Find(X509FindType.FindBySubjectDistinguishedName, oX509Certificate2.Subject.ToString(), false);

                if (collection1.Count == 0)
                {
                    throw new Exception("Framework: Problemas no certificado digital.");
                }
                else
                {
                    oX509Cert = collection1[0];

                    string x = oX509Cert.GetKeyAlgorithm().ToString();

                    // Create a new XML document.
                    var oXML = new XmlDocument();

                    // Format the document to ignore white spaces.
                    oXML.PreserveWhitespace = false;

                    // Load the passed XML file using it’s name.
                    try
                    {
                        oXML.LoadXml(XML);

                        // cheching the elemento will be sign 
                        int qtdeRefUri = oXML.GetElementsByTagName(pUri).Count;

                        if (qtdeRefUri == 0)
                        {
                            throw new Exception("Framework: A tag de assinatura " + pUri.Trim() + " não existe");
                        }
                        else
                        {
                            if (qtdeRefUri > 1)
                            {
                                throw new Exception("Framework: A tag de assinatura " + pUri.Trim() + " não é unica");
                            }
                            else
                            {
                                try
                                {
                                    // Create a SignedXml object.
                                    SignedXml signedXml = new SignedXml(oXML);

                                    // Add the key to the SignedXml document
                                    signedXml.SigningKey = oX509Cert.PrivateKey;

                                    // Create a reference to be signed
                                    Reference reference = new Reference();

                                    XmlAttributeCollection _Uri = oXML.GetElementsByTagName(pUri).Item(0).Attributes;

                                    foreach (XmlAttribute _atributo in _Uri)
                                    {
                                        if (_atributo.Name == "Id")
                                            reference.Uri = "#" + _atributo.InnerText;
                                    }

                                    // Add an enveloped transformation to the reference.
                                    XmlDsigEnvelopedSignatureTransform env = new XmlDsigEnvelopedSignatureTransform();
                                    reference.AddTransform(env);

                                    XmlDsigC14NTransform c14 = new XmlDsigC14NTransform();
                                    reference.AddTransform(c14);

                                    // Add the reference to the SignedXml object.
                                    signedXml.AddReference(reference);

                                    // Create a new KeyInfo object
                                    KeyInfo keyInfo = new KeyInfo();

                                    // Load the certificate into a KeyInfoX509Data object
                                    // and add it to the KeyInfo object.
                                    keyInfo.AddClause(new KeyInfoX509Data(oX509Cert));

                                    // Add the KeyInfo object to the SignedXml object.
                                    signedXml.KeyInfo = keyInfo;
                                    signedXml.ComputeSignature();

                                    // Get the XML representation of the signature and save
                                    // it to an XmlElement object.
                                    XmlElement xmlDigitalSignature = signedXml.GetXml();

                                    // save element on XML 
                                    oXML.DocumentElement.AppendChild(oXML.ImportNode(xmlDigitalSignature, true));
                                    XmlDocument XMLDoc = new XmlDocument();
                                    XMLDoc.PreserveWhitespace = false;
                                    XMLDoc = oXML;

                                    // XML document already signed 
                                    XML = XMLDoc.OuterXml;

                                    oXML = null;
                                    signedXml = null;
                                    env = null;
                                    c14 = null;

                                }
                                catch (Exception oError)
                                {
                                    throw new Exception("Framework: Erro ao assinar o documento XML." + oError.Message);
                                }
                            }
                        }
                    }
                    catch (Exception oError)
                    {
                        throw new Exception("Framework: XML mal formatado." + oError.Message);
                    }
                }
            }
            catch (Exception oError)
            {
                throw new Exception("Framework: Problema ao acessar o certificado digital." + oError.Message);
            }

            return XML;
        } 
        
        #endregion
    }
}
