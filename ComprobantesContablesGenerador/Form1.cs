using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ComprobantesContablesGenerador
{
    public partial class Form1 : Form
    {
        // el objeto random debe ser una variable de instancia (global) y solo se puede instanciar 1 vez para que los numeros no se repitan
        Random r;

        public Form1()
        {
            InitializeComponent();
            //Asigno las rutas por defecto que es dentro de la carpeta "bin" del aplicativo
            txtParties.Text = Application.StartupPath.ToString() + @"\parties.xml";
            txtCuentas.Text = Application.StartupPath.ToString() + @"\cuentas.xml";
            txtComprobante.Text = Application.StartupPath.ToString() + @"\Comprobante.xml.xml";
            r = new Random();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            //Ésta clase nos ayuda a medir tiempos
            Stopwatch tiempo = Stopwatch.StartNew();
            //Realizar el proceso el numero de veces que se asigne en el numericUpDown
            for (int i = 0; i < nupCantidadComprobantes.Value; i++)
            {
                //Instancio la clase Comprobante y uso sus funciones para generar Numero y la FECHA y serán asignados a la spropiedades de la clase
                Comprobante oComprobante = new Comprobante(txtComprobante.Text);
                oComprobante.generarNumeroComprobante();
                oComprobante.generarFecha();

                //creo una instancia de la clase partie´, de la cual obtendré los nodos party para reemplazar en la Empresa y Tercero
                //Se le envía dentro del contructor la ruta del archivo parties.xml
                Parties oParties = new Parties(txtParties.Text);
                //Limpio los nodos hijo del nodo Empresa
                oComprobante.limpiarEmpresa();
                //Añado un nodo Party obtenido de la instancia oParties.getRandomParty(). este nodo es aleatorio
                oComprobante.addEmpresaPartie(oParties.getRandomParty());
                //Limpio los nodos hijo del nodo Tercero
                oComprobante.limpiarTercero();
                //Añado un nodo Party obtenido de la instancia oParties.getRandomParty(). este nodo es aleatorio
                oComprobante.addTerceroPartie(oParties.getRandomParty());

                //Creo una lista para guardar todos los nodos "Asiento" que genere
                List<XmlNode> lstAsientos = new List<XmlNode>();

                //Aleatoriamente obtendo la cantidad de orderLines que se crearán (entre 1 y 10)
                //el Random Realmente retorna el MaxValue - 1. así que debe ser entre 1 y 11
                int cantidadAsientos = r.Next(1,11);
                for (int j = 0; j < cantidadAsientos; j++)
                {
                    //Obtengo un Asiento aleatoriamente
                    XmlNode nodeAsiento = oComprobante.getAsientoAleatorio();
                    //agrego a la lista de Asientos
                    lstAsientos.Add(nodeAsiento);
                }

                //Elimino todos los nodos Asiento para poder empezar a añadir los nodos que ya se generaron en el proceso anterior
                oComprobante.limpiarContabilizacion();

                for (int j = 0; j < lstAsientos.Count; j++)
                {
                    oComprobante.agregarAsiento(lstAsientos[j]);
                }

                //Ruta Folder de los Comprobantes
                string rutaBase = Application.StartupPath.ToString() + @"\Comprobantes";
                //ruta para guardar el nuevo archivo dependiendo del ID de la Order de compra
                string ruta = rutaBase + @"\" + oComprobante.Numero + ".xml";
                //Verifico que se haya creado la carpeta COmprobantes dentro de la ruta del proyecto, de lo contrario, la creo
                if (!Directory.Exists(rutaBase))
                    Directory.CreateDirectory(rutaBase + @"\Comprobantes");
                //Y Guardo
                oComprobante.Xml.Save(ruta);
                lblTiempoTotal.Text = "Tiempo total: " + tiempo.Elapsed + " milésimas de segundos";
                //Abro la carpeta donde se guardan los comprobantes
                System.Diagnostics.Process.Start(rutaBase);
            }
        }

        private void examinar(TextBox target)
        {
            //muestro el cuadro de diálogo
            openFileDialog1.Filter = "Archivos XML|*.xml";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                target.Text = openFileDialog1.FileName;
                //string strParties = File.ReadAllText(archivo);
            } 
        }

        private void btnExaminarComprobante_Click(object sender, EventArgs e)
        {
            examinar(txtComprobante);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExaminarCuentas_Click(object sender, EventArgs e)
        {
            examinar(txtCuentas);
        }

        private void btnExaminarParties_Click(object sender, EventArgs e)
        {
            examinar(txtParties);
        }
    }
}
