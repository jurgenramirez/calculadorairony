using CalculadoraIrony.analizador;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Ast;
using Irony.Parsing;


namespace CalculadoraIrony
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEjecutar_Click(object sender, EventArgs e)

        {
            Sintactico sintactico = new Sintactico();
            Acciones acciones = new Acciones();
            if (txtEntrada.Text != null)
            {
                ParseTreeNode raiz = sintactico.analizar(txtEntrada.Text.ToString());
                if (raiz != null)
                {
                    String salida = "Analisis Realizado correctamente \n Resultado ="
                        +Convert.ToString(acciones.realizarAccion(raiz));
                    txtSalida.Text = salida;
                 

                }
                else
                {
                    txtSalida.Text = "Entrada no valida";
                }

            }
          
            sintactico.analizar(txtEntrada.ToString());

        }
    }
}
