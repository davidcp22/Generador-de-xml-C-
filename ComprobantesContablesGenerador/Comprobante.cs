using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ComprobantesContablesGenerador
{
    class Comprobante
    {
        private XmlDocument xml;
        private string numero;
        private XmlNamespaceManager nsmgr;
        private Random r;

        public Comprobante(string ruta)
        {
            //la ruta del xml es fija dentro del archivo raíz de la aplciación
            string xmlPath;

            //Si se envía una ruta nula, asumiré por defecto la siguiente ruta
            if (string.IsNullOrEmpty(ruta))
                xmlPath = Application.StartupPath.ToString() + "\\comprobante.xml.xml";
            else
                xmlPath = ruta;
            

            xml = new XmlDocument();
            xml.Load(xmlPath);

            //Como el XML Order-template.xml tiene nameSpaces, debe haber un nameSpaceManager para poder efectuar consultas XPath sobre él
            setNameSpaceManager();

            r = new Random();
        }

        //Esta propiedad es para poder guardar el XMl externamente con más facilidad (con la funcion .save("..."))
        public XmlDocument Xml
        {
            get { return xml; }
            set { xml = value; }
        }

        public string Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        private void setNameSpaceManager()
        {
            //El NameSpaceManager simplemente guarda las "referencias" pro asi decirlos de los nameSpaces para poder realizar las consultas dentro del documento XMl
            nsmgr = new XmlNamespaceManager(xml.NameTable);
            nsmgr.AddNamespace("ns1", "http://creativosdigitales.co/schema/docusfera.xsd");           
        }

        public void setSingleNodo(string xpath, string value)
        {
            XmlNode node = xml.SelectSingleNode(xpath, nsmgr);
            node.InnerText = value;
        }

        public void generarNumeroComprobante()
        {
            Random r = new Random();
            string posibles = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            int longitud = posibles.Length;
            char letra;
            //el Numero debe ser de 10 caracteres
            int longitudnuevacadena = 10;
            string nuevacadena = "";
            //hasta alcanzar un tamaño de 10 caracteres concatenaré un caracter dentro del string "Posibles" buscado con un indice aleatorio
            for (int i = 0; i < longitudnuevacadena; i++)
            {
                letra = posibles[r.Next(longitud)];
                nuevacadena += letra.ToString();
            }

            this.numero = nuevacadena;

            //Guardo el Numero dentro del XML
            setSingleNodo("/*/Numero", nuevacadena);
        }

        public void generarFecha()
        {
            DateTime randomeDate;

            //Este fragmento de codigo genera una fecha aleatoria
            DateTime start = new DateTime(1995, 1, 1);
            Random gen = new Random();

            int range = (DateTime.Today - start).Days;
            randomeDate = start.AddDays(gen.Next(range));

            //Guardo la fecha en el nodo correspondiente
            //hago un subString para solo mostrar los primeros 10 caracteres, eso cortaría la hora HH:MM:HH
            setSingleNodo("/*/Fecha", randomeDate.ToString().Substring(0,10));
        }

        public void limpiarEmpresa()
        {
            Xml.SelectSingleNode("/*/Empresa", nsmgr).RemoveAll();
        }
        public void limpiarTercero()
        {
            Xml.SelectSingleNode("/*/Tercero", nsmgr).RemoveAll();
        }

        public void addEmpresaPartie(XmlNode nodoParaAgregar)
        {
            XmlNode node = Xml.SelectSingleNode("/*/Empresa", nsmgr);
            node.AppendChild(node.OwnerDocument.ImportNode(nodoParaAgregar, true));
        }

        public void addTerceroPartie(XmlNode nodoParaAgregar)
        {
            XmlNode node = Xml.SelectSingleNode("/*/Tercero", nsmgr);
            node.AppendChild(node.OwnerDocument.ImportNode(nodoParaAgregar, true));
        }

        public string getCreditoODebitoAleatorio()
        {
            return r.Next().ToString();
        }

        //Obtiene un Nodo Asiento del archivo Comprobantes.xml aleatoriamente
        public XmlNode getAsientoAleatorio()
        {
            //obtengo el toda la lsita de Asientos que tenga el archivo Comprobantes.xml ya que no hay mas referencias de estos asientos
            XmlNodeList nodes = xml.SelectNodes("/*/Contabilizacion/ns1:Asiento", nsmgr);
            //selecciono un nodo de la lsita aleatoriamente
            XmlNode node = nodes[r.Next(nodes.Count)];

            //Si el resultado de este random es 0, asignaré un crédito
            //Si el resultado de este random es 1, asignaré un Débito
            int randomeCreditoDebito = r.Next(0, 2);
            if (randomeCreditoDebito == 0)
            {
                node.SelectSingleNode("Creditos", nsmgr).InnerText = getCreditoODebitoAleatorio();
                node.SelectSingleNode("Debitos", nsmgr).InnerText = "0";
            }
            else
                if (randomeCreditoDebito == 1)
                {
                    node.SelectSingleNode("Debitos", nsmgr).InnerText = getCreditoODebitoAleatorio();
                    node.SelectSingleNode("Creditos", nsmgr).InnerText = "0";
                }

            return node;
        }

        /// <summary>
        /// Eliminar todos los hijos (Asientos) del Comprobante actual
        /// </summary>
        public void limpiarContabilizacion()
        {
            //Esta funcion limpia todo para poder empezar a insertar los asientos generados aleatoreamente, desde cero
            xml.SelectSingleNode("/*/Contabilizacion", nsmgr).RemoveAll();
        }

        public void agregarAsiento(XmlNode asiento)
        {
            XmlNode nodeContabilizacion = Xml.SelectSingleNode("/*/Contabilizacion", nsmgr);
            nodeContabilizacion.AppendChild(nodeContabilizacion.OwnerDocument.ImportNode(asiento, true));
        }
    }

}
