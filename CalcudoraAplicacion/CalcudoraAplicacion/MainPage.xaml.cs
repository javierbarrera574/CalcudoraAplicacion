using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace CalcudoraAplicacion
{
    public partial class MainPage : ContentPage
    {
        double Resultado = 0;

        int ResultadoResto;
        public MainPage()
        {
            InitializeComponent();
            OpcionOperacion.Items.Add(Operacion.Suma.ToString());
            OpcionOperacion.Items.Add(Operacion.Resta.ToString());
            OpcionOperacion.Items.Add(Operacion.Multiplicacion.ToString());
            OpcionOperacion.Items.Add(Operacion.Division.ToString());
            OpcionOperacion.Items.Add(Operacion.Potenciacion.ToString());
            OpcionOperacion.Items.Add(Operacion.Radicacion.ToString());
            OpcionOperacion.Items.Add(Operacion.ValorAbsoluto.ToString());
            OpcionOperacion.Items.Add(Operacion.Resto.ToString());
            OpcionOperacion.Items.Add(Operacion.Exponenciacion.ToString());
            OpcionOperacion.Items.Add(Operacion.MaximoValor.ToString());
            OpcionOperacion.SelectedIndexChanged += OpcionOperacion_SelectedIndexChanged;
            calcular.Clicked += Calcular_Clicked;
        }

        private void OpcionOperacion_SelectedIndexChanged(object sender, EventArgs e) { }

        private void Calcular_Clicked(object sender, EventArgs e)
        {
            Operacion Operacion;
            
            Operacion = (Operacion)OpcionOperacion.SelectedItem;
            int Numero1 = Int32.Parse(txtNumero1.Text);
            int Numero2 = Int32.Parse(txtNumero2.Text);
            switch (Operacion)
            {
                case Operacion.Suma:
                    Console.WriteLine(ValidarEntradas.Operaciones);
                    Resultado = Numero1 + Numero2;
                    break;
                case Operacion.Resta:
                    Console.WriteLine(ValidarEntradas.Operaciones);
                    Resultado = Numero1 - Numero2;
                    break;
                case Operacion.Multiplicacion:
                    Console.WriteLine(ValidarEntradas.Operaciones);
                    Resultado = Numero1 * Numero2;
                    break;
                case Operacion.Division:
                    Console.WriteLine(ValidarEntradas.Operaciones);
                    try
                    {
                        Resultado = Numero1 / Numero2;
                    }
                    catch (DivideByZeroException)
                    {
                        if (Numero2.Equals(0))
                        {                       
                            lblResultado.Text = "No se puede dividir por cero";
                        }
                    }                    break;
                case Operacion.Potenciacion:
                    Console.WriteLine(ValidarEntradas.Operaciones);
                    Resultado = Math.Pow(Numero1, Numero2);
                    break;
                case Operacion.Radicacion:
                    Resultado = Math.Sqrt(Numero1);
                    break;
                case Operacion.ValorAbsoluto:
                    Resultado = Math.Abs(Numero1);
                    break;
                case Operacion.Resto:
                    Console.WriteLine(ValidarEntradas.Operaciones);
                    Resultado = Math.DivRem(Numero1, Numero2, out ResultadoResto);
                    break;
                case Operacion.Exponenciacion:
                    Resultado = Math.Exp(Numero1);
                    break;
                case Operacion.MaximoValor:
                    Console.WriteLine(ValidarEntradas.Operaciones);
                    Resultado = Math.Max(Numero1, Numero2);
                    break;
                default:
                    Console.WriteLine("No es posible realizar calculos multiples");
                    break;       
            }
            lblResultado.Text = Resultado + "";
        }

        public class ValidacionesGlobales<T> : Exception
        {
            public ValidacionesGlobales() : base("No se admiten campos vacios") { }

            #region
            //public static readonly Predicate<MainPage> petes =
            //    (n) => !(string.IsNullOrEmpty(n.txtNumero1.Text) && string.IsNullOrEmpty(n.txtNumero2.Text));

            #endregion

            public static readonly Predicate<MainPage> CamposNoNulos = (n) =>
            {
                try
                { 
                    bool Validar = !(string.IsNullOrEmpty(n.txtNumero1.Text) || string.IsNullOrEmpty(n.txtNumero2.Text));
                }

                catch (Exception)
                {
                    throw new ValidacionesGlobales<T>();
                }
                return true;
                #region
                //if (string.IsNullOrEmpty(n.txtNumero1.Text) || string.IsNullOrEmpty(n.txtNumero2.Text))
                //{
                //    throw new ValidacionesGlobales<T>();
                //}
                //return true;
                #endregion
            };

        }

        public class ValidarEntradas
        {
            //Diccionario de predicados

            public static readonly Dictionary<Operacion, (Func<double, double, double> funcion, Predicate<MainPage> validador)> Operaciones
              = new Dictionary<Operacion, (Func<double, double, double>, Predicate<MainPage>)>
              {
                    {
                        Operacion.Suma, ((a, b) => a + b, (Page) => ValidacionesGlobales<MainPage>.CamposNoNulos(Page))
                    },
                    {
                        Operacion.Resta, ((a, b) => a - b, (Page) => ValidacionesGlobales<MainPage>.CamposNoNulos(Page))
                    },
                    {
                        Operacion.Multiplicacion, ((a, b) => a * b, (Page) => ValidacionesGlobales<MainPage>.CamposNoNulos(Page))
                    },
                    {
                        Operacion.Division, ((a, b) => a / b, (Page) => ValidacionesGlobales<MainPage>.CamposNoNulos(Page))
                    },
                    {
                        Operacion.Potenciacion, ((a, b) => Math.Pow(a,b), (Page) => ValidacionesGlobales<MainPage>.CamposNoNulos(Page))
                    },
                    {
                        Operacion.Resto, ((a, b) => RealizarDivisionConResto(a,b), (Page) => ValidacionesGlobales<MainPage>.CamposNoNulos(Page))
                    },
                    {
                        Operacion.MaximoValor, ((a, b) => Math.Max(a,b), (Page) => ValidacionesGlobales<MainPage>.CamposNoNulos(Page))
                    },

              };

            private static double RealizarDivisionConResto(double a, double b)
            {
                /*
                 * Como no es posible representar la función Math.DivRem como una expresión lambda dentro de un diccionario 
                 * de Func y Predicate directamente debido al uso de la palabra reservada out. En este caso, 
                 * envuelvo la funcion Math.DivRem en una función separada que maneje la lógica de out
                 * y utilizo esta función en el diccionario de Func.
                 */

                int Cociente;
                int resultadoResto = Math.DivRem((int)a, (int)b, out Cociente);
                return resultadoResto;
            }    
        }

        public class ValidacionOperacion
        {
            //Params es una forma dinamica de crear elementos sin importar la longitud de este
            public static bool Validar<T>(T operacion, params Predicate<T>[] Validaciones) =>
                Validaciones.ToList().Where(d => 
                {
                    return !d(operacion);
                }).Count()>=0;
        }     
    }

    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = false)]
    public class NombreAttribute : Attribute
    {
        public string Nombre { get; set; }
        public NombreAttribute(string nombre)
        {
            this.Nombre = nombre;
        }
    }
    public enum Operacion 
    {
        [Nombre("Suma")]
        Suma= 1,
        [Nombre("Resta")]
        Resta=2,
        [Nombre("Multiplicación")]
        Multiplicacion=3,
        [Nombre("División")]
        Division=4,
        [Nombre("Potenciación")]
        Potenciacion=5,
        [Nombre("Radicación")]
        Radicacion=6,
        [Nombre("Valor absoluto")]
        ValorAbsoluto=7,
        [Nombre("Resto")]
        Resto=8,
        [Nombre("Exponenciación")]
        Exponenciacion=9,
        [Nombre("Maximo valor")]
        MaximoValor=10
    }
}