using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ComprobantesContablesGenerador
{
    class Cuentas
    {
        //constructor para recibir la ruta del archivo de Cuentas 
        public Cuentas(string ruta)
        {
            xml = new XmlDocument();
            xml.Load(ruta);
            setNameSpaceManager();
            r = new Random();
        }

        Random r;
        private XmlDocument xml;
        private XmlNamespaceManager nsmgr;

        private string cuenta;
        private string nombre;

        public XmlDocument Xml
        {
            get { return xml; }
            set { xml = value; }
        }

        public string Cuenta
        {
            get { return cuenta; }
            set { cuenta = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private void setNameSpaceManager()
        {
            //El NameSpaceManager simplemente guarda las "referencias" pro asi decirlos de los nameSpaces para poder realizar las consultas dentro del documento XMl
            nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("ns1", "http://creativosdigitales.co/schema/docusfera.xsd");
        }

        //Cada vez que se llame esta funcion, los valores de la clase "cuenta" y "nombre" cambiarán aleatoreamente
        private void rotarValoresAleatoreamente()
        {
            //obtengo el toda la lsita de parties que tenga el archivo xml
            XmlNodeList nodes = xml.SelectNodes("/*/Cuenta", nsmgr);
            //selecciono un nodo de la lsita aleatoriamente
            XmlNode node = nodes[r.Next(nodes.Count)];
            //Asigno las propiedades
            cuenta = node.SelectSingleNode("Codigo").InnerText;
            nombre = node.SelectSingleNode("Nombre").InnerText;
        }

    }
}
