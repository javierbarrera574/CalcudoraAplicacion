using System;
using Xamarin.Forms;

namespace CalcudoraAplicacion
{
    public partial class MainPage : ContentPage
    {
        double Resultado = 0;

        int ResultadoResto;

        //private readonly Operacion _operacion;

        #region
        //public MainPage(Operacion operacion)
        //{
        //    this._operacion = operacion;
        //}
        #endregion

        public MainPage()//(Operacion operacion)
        {
           // this._operacion = operacion;
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

            #region
            //if (!string.IsNullOrEmpty(txtNumero1.Text) && !string.IsNullOrEmpty(txtNumero2.Text))
            //{
            #endregion
            Operacion = (Operacion)OpcionOperacion.SelectedItem;
                int Numero1 = Int32.Parse(txtNumero1.Text);
                int Numero2 = Int32.Parse(txtNumero2.Text);

            switch (Operacion)
            {
                case Operacion.Suma:
                    Resultado = Numero1 + Numero2;
                    break;
                case Operacion.Resta:
                    Resultado = Numero1 - Numero2;
                    break;
                case Operacion.Multiplicacion:
                    Resultado = Numero1 * Numero2;
                    break;
                case Operacion.Division:
                    Resultado = Numero1 / Numero2;
                    break;
                case Operacion.Potenciacion:
                    Resultado = Math.Pow(Numero1, Numero2);
                    break;
                case Operacion.Radicacion:
                    Resultado = Math.Sqrt(Numero1);
                    break;
                case Operacion.ValorAbsoluto:
                    Resultado = Math.Abs(Numero1);
                    break;
                case Operacion.Resto:
                    Resultado = Math.DivRem(Numero1, Numero2, out ResultadoResto);
                    break;
                case Operacion.Exponenciacion:
                    Resultado = Math.Exp(Numero1);
                    break;
                case Operacion.MaximoValor:
                    Resultado = Math.Max(Numero1, Numero2);
                    break;
                default:
                    Console.WriteLine("No es posible realizar calculos multiples");
                    break;       
            }
            #region
            //if (op == "suma")
            //{
            //    Resultado = Numero1 + Numero2;
            //}
            //else if (op == "resta")
            //{
            //    Resultado = Numero1 - Numero2;
            //}
            //else if (op == "multiplicacion")
            //{
            //    Resultado = Numero1 * Numero2;
            //}
            //else if (op == "division")
            //{
            //    Resultado = Numero1 / Numero2;
            //}
            //else
            //{
            //    Console.WriteLine("no se pueden hacer calculos multiples");
            //}
            #endregion
            #region
            //}
            //else
            //{
            //    DisplayAlert("Datos erroneos", "Llene los espacios", "Ok");
            //}
            #endregion
            lblResultado.Text = Resultado + "";
        }
    }
    public enum Operacion
    {
        Suma=1,
        Resta=2,
        Multiplicacion=3,
        Division=4,
        Potenciacion=5,
        Radicacion=6,
        ValorAbsoluto=7,
        Resto=8,
        Exponenciacion=9,
        MaximoValor=10
    }
}
