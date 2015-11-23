using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ComprobantesContablesGenerador
{
    class Parties
    {
        //constructor para recibir la ruta del archivo de parties (empresas)
        public Parties(string ruta)
        {
            xml = new XmlDocument();
            xml.Load(ruta);
            setNameSpaceManager();
            r = new Random();
        }

        Random r;
        private XmlDocument xml;
        private XmlNamespaceManager nsmgr;

        public XmlDocument Xml
        {
            get { return xml; }
            set { xml = value; }
        }

        private void setNameSpaceManager()
        {
            nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("cbc", "urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2");
            nsmgr.AddNamespace("cac", "urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2");
            nsmgr.AddNamespace("", "urn:oasis:names:specification:ubl:schema:xsd:Catalogue-2");
        }

        public XmlNode getRandomParty()
        {
            //obtengo el toda la lsita de parties que tenga el archivo xml
            XmlNodeList nodes = xml.SelectNodes("/*/cac:Party", nsmgr);
            //selecciono un nodo de la lsita aleatoriamente
            XmlNode node = nodes[r.Next(nodes.Count)];
            return node;
        }
    }
}
