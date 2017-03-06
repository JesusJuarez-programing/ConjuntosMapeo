﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
//Importamos esta libreria que es un dll, esto para utilizar cuadros de input.
using InputKey;

namespace ConjuntosMapeo
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        //Declaramos nuestras listas o vectores dinamicos.
        List<String> universo = new List<String>();
        List<String> mundoA = new List<String>();
        List<String> mundoB = new List<String>();
        List<String> mundoC = new List<String>();
        //Declarancion de un auxiliar.
        String auxiliar, primero, segundo, tercero;
        //Declaracion de variables auxiliares.
        Boolean operacionA, operacionB, operacionC, operacionUnion, operacionComple, operacionInter, operacionDiferen,
                operacionConca, operacionProducto, operacionPotencia, operacionPertenencia;
        //Contador.
        byte contador = 0;

        private void union(List<String> uno, List<String> dos)
        {
            //Metodo para unir dos listas.
            IEnumerable<String> resultadoU = uno.Union(dos);
            //Ciclo para imprimir el resultado.
            foreach (String valor in resultadoU)
            {
                label15.Text += valor + ", ";
            }
        }

        private void complemento(List<String> uno)
        {
            List<String> resultadoC = new List<String>();
            bool auxx = false; String auxxxx = "";
            for (int f = 0; f < universo.Count; f++)
            {
                for (int o = 0; o < uno.Count; o++)
                {
                    if (uno[o] == universo[f])
                    {
                        f++; o++;
                        break;
                    }
                    else
                    {
                        resultadoC.Add(universo[f]);

                        break;
                    }

                }
            }
            foreach (String valor in resultadoC)
            {
                label15.Text += valor + ", ";
            }
        }

        private void interseccion(List<String> uno, List<String> dos)
        {
            //Metodo para unir dos listas.
            IEnumerable<String> resultadoI = uno.Intersect(dos);
            //Ciclo para imprimir el resultado.
            resultadoI.Count();
            if (resultadoI.Count().Equals(0))
            {
                label15.Text = "No hay valores.";
            }
            foreach (String valor in resultadoI)
            {
                label15.Text += valor + ", ";
            }
        }

        private void diferencia(List<String> uno, List<String> dos)
        {
            IEnumerable<String> resultadoD = uno.Except(dos);
            //Ciclo para imprimir el resultado.
            foreach (String valor in resultadoD)
            {
                label15.Text += valor + ", ";
            }

        }

        

        private void producto(List<String> uno, List<String> dos)
        {
            List<String> resultadoP = new List<String>();
            for (int f = 0; f < uno.Count; f++)
            {
                for (int o = 0; o < dos.Count; o++)
                {
                    resultadoP.Add(dos[o] + uno[f]);
                }
            }
            foreach (String valor in resultadoP)
            {
                label15.Text += valor + ", ";
            }
        }

        private void concatenacion(List<String> uno, List<String> dos)
        {
            //Metodo para unir dos listas.
            IEnumerable<String> resultadoU = dos.Concat(uno);
            //Ciclo para imprimir el resultado.
            foreach (String valor in resultadoU)
            {
                label15.Text += valor + ", ";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnUniverso_Click(object sender, EventArgs e)
        {
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato");
            //Lo guardamos en nuestra lista correspondiente.
            universo.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label4.Text += auxiliar + "\n";
        }

        private void btnA_Click(object sender, EventArgs e)
        {
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato");
            //Lo guardamos en nuestra lista correspondiente.
            mundoA.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label5.Text += auxiliar + "\n";
        }

        private void btnB_Click(object sender, EventArgs e)
        {
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato");
            //Lo guardamos en nuestra lista correspondiente.
            mundoB.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label7.Text += auxiliar + "\n";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            operacionA = true;
            txtOpera.Text += "A";

            if (primero == "")
            {
                primero = "A";
            }
            else if (segundo == "")
            {
                segundo = "A";
            }
            else
            {
                tercero = "A";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            operacionB = true;
            txtOpera.Text += "B";
            if (primero == "")
            {
                primero = "B";
            }
            else if (segundo == "")
            {
                segundo = "B";
            }
            else
            {
                tercero = "B";
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            label15.Text = "";
            txtOpera.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            operacionC = true;
            txtOpera.Text += "C";
            if (primero == "")
            {
                primero = "C";
            }
            else if (segundo == "")
            {
                segundo = "C";
            }
            else
            {
                tercero = "C";
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (operacionUnion)
            {
                auxiliarUnion();
            }
            else if (operacionComple)
            {
                auxiliarComplemento();
            }
            else if (operacionInter)
            {
                auxiliarInterseccion();
            }
            else if (operacionDiferen)
            {
                auxiliarDiferencia();
            }
            else if (operacionConca)
            {
                auxiliarConcatenacion();
            }
            else if (operacionProducto)
            {
                auxiliarProducto();
            }
            else if (operacionPotencia)
            {
                auxiliarPotencia();
            }
            primero = ""; segundo = ""; tercero = "";
            operacionA = false; operacionB = false; operacionC = false;
        }

        private void auxiliarUnion()
        {
            if (operacionA && operacionB)
            {
                if (primero == "A" && segundo == "B")
                {
                    union(mundoA, mundoB);
                }
                else
                {
                    union(mundoB, mundoA);
                }
            }
            else if (operacionA && operacionC)
            {
                if (primero == "A" && segundo == "C")
                {
                    union(mundoA, mundoC);
                }
                else
                {
                    union(mundoC, mundoA);
                }
            }
            else
            {
                if (primero == "B" && segundo == "C")
                {
                    union(mundoB, mundoC);
                }
                else
                {
                    union(mundoC, mundoB);
                }
            }
        }

        private void auxiliarConcatenacion()
        {
            if (operacionA && operacionB)
            {
                if (primero == "A" && segundo == "B")
                {
                    concatenacion(mundoA, mundoB);
                }
                else
                {
                    concatenacion(mundoB, mundoA);
                }
            }
            else if (operacionA && operacionC)
            {
                if (primero == "A" && segundo == "C")
                {
                    concatenacion(mundoA, mundoC);
                }
                else
                {
                    concatenacion(mundoC, mundoA);
                }
            }
            else
            {
                if (primero == "B" && segundo == "C")
                {
                    concatenacion(mundoB, mundoC);
                }
                else
                {
                    concatenacion(mundoC, mundoB);
                }
            }
        }

        private void auxiliarProducto()
        {
            if (operacionA && operacionB)
            {
                if (primero == "A" && segundo == "B")
                {
                    producto(mundoA, mundoB);
                }
                else
                {
                    producto(mundoB, mundoA);
                }
            }
            else if (operacionA && operacionC)
            {
                if (primero == "A" && segundo == "C")
                {
                    producto(mundoA, mundoC);
                }
                else
                {
                    producto(mundoC, mundoA);
                }
            }
            else
            {
                if (primero == "B" && segundo == "C")
                {
                    producto(mundoB, mundoC);
                }
                else
                {
                    producto(mundoC, mundoB);
                }
            }
        }

        private void auxiliarDiferencia()
        {
            if (operacionA && operacionB)
            {
                if (primero == "A" && segundo == "B")
                {
                    diferencia(mundoA, mundoB);
                }
                else
                {
                    diferencia(mundoB, mundoA);
                }
            }
            else if (operacionA && operacionC)
            {
                if (primero == "A" && segundo == "C")
                {
                    diferencia(mundoA, mundoC);
                }
                else
                {
                    diferencia(mundoC, mundoA);
                }
            }
            else
            {
                if (primero == "B" && segundo == "C")
                {
                    diferencia(mundoB, mundoC);
                }
                else
                {
                    diferencia(mundoC, mundoB);
                }
            }

        }

        private void auxiliarInterseccion()
        {
            if (operacionA && operacionB)
            {
                interseccion(mundoA, mundoB);
            }
            else if (operacionA && operacionC)
            {
                interseccion(mundoA, mundoC);
            }
            else
            {
                interseccion(mundoB, mundoC);
            }
        }

        private void auxiliarComplemento()
        {
            if (operacionA)
            {
                complemento(mundoA);
            }
            else if (operacionB)
            {
                complemento(mundoB);
            }
            else
            {
                complemento(mundoC);
            }
        }

        private void auxiliarPotencia()
        {
            if (operacionA)
            {
                potencia(mundoA);
            }
            else if (operacionB)
            {
                potencia(mundoB);
            }
            else
            {
                potencia(mundoC);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "'";
            operacionComple = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "∪ ";
            operacionUnion = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "∩";
            operacionInter = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "--";
            operacionDiferen = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "x";
            operacionProducto = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "P()";
            operacionPotencia = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "⊆ ";
            operacionPertenencia = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "Con";
            operacionConca = true;
        }

        private void btnC_Click(object sender, EventArgs e)
        {
            auxiliar = "";
            //Guardamos en la variable el valor introducido por el usuario.
            auxiliar = InputDialog.mostrar("Introduzca algun dato");
            //Lo guardamos en nuestra lista correspondiente.
            mundoC.Add(auxiliar);
            //Lo imprimimos para ver el valor.
            label9.Text += auxiliar + "\n";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            txtOpera.Text += "⊃";
            operacionPertenencia = true;
        }
    }
}
