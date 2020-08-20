using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnalizadorLexico
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLeer_Click(object sender, RoutedEventArgs e)
        {
            String oracion = txtOracion.Text;
            int tamOracion = oracion.Length;
            String[] tokens = oracion.Split(' ');
            //verificamos cada palabra
            for (int i=0; i < tokens.Length; i++)
            {
                int contDigitos = 0;
                Boolean dec = false;
                Boolean moneda = false;

                //verificamos si puede ser una moneda
                if (tokens[i].Length > 2)
                {
                    if (tokens[i][0].Equals('Q'))
                    {
                        moneda = true;
                        if (tokens[i][tokens[i].Length - 1].Equals('.'))
                        {
                            dec = false;
                        }
                        else
                        {
                            dec = true;
                        }
                    }
                }

                //contamos cuantos digitos tiene la cadena
                for (int j = 0; j < tokens[i].Length; j++)
                {     
                                       
                    if (char.IsNumber(tokens[i][j]))
                    {
                        contDigitos++;
                    }
                    if (tokens[i][j].Equals('.') && j != (tokens[i].Length-1) && moneda == false)
                    {
                        dec = true;
                    }

                }

               //agregamos a la palabra su identificador
               if (contDigitos == tokens[i].Length)
                {
                    tokens[i] += "   ->   Entero";
                }
               else if (contDigitos == tokens[i].Length-1 && dec && moneda == false)
                {
                    tokens[i] += "   ->   Moneda";
                }
                else if (moneda && dec && contDigitos == tokens[i].Length - 1)
                {
                    tokens[i] += "   ->   Moneda";
                }
                else if (moneda && dec && contDigitos == tokens[i].Length - 2)
                {
                    tokens[i] += "   ->   Moneda";
                }
                else
                {
                    tokens[i] += "   ->   Palabra";
                }

            }
            //mostramos a la lista los resultados
            listTokens.Items.Clear();
            for (int i = 0; i < tokens.Length; i++)
            {                
                listTokens.Items.Add(tokens[i]);
            }                
        }
    }
}
