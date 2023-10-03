using System;
using Xamarin.Forms;

namespace CalcudoraAplicacion
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            OpcionOperacion.ItemsSource = Enum.GetValues(typeof(Operacion));
            OpcionOperacion.SelectedIndexChanged += OpcionOperacion_SelectedIndexChanged;
            calcular.Clicked += Calcular_Clicked;
        }
        private void OpcionOperacion_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Calcular_Clicked(object sender, EventArgs e)
        {
            double numero1, numero2 = 0, resultado=0;

            bool Validar = double.TryParse(txtNumero1.Text, out numero1) 
                && double.TryParse(txtNumero2.Text, out numero2);  

            if (Validar)
            {
                Operacion operacionSeleccionada = (Operacion)OpcionOperacion.SelectedItem;

                switch (operacionSeleccionada)
                {
                    case Operacion.Suma:
                        resultado = numero1 + numero2;
                        break;
                    case Operacion.Resta:
                        resultado = numero1 - numero2;
                        break;
                    case Operacion.Multiplicacion:
                        resultado = numero1 * numero2;            
                        break;
                    case Operacion.Division:
                        if (!numero2.Equals(0))
                        {      
                            resultado = numero1 / numero2;
                        }
                        else
                        {
                            lblResultado.Text = "No se puede dividir por cero";
                            return;
                        }
                        break;
                    case Operacion.Potenciacion:
                        resultado = Math.Pow(numero1, numero2);
                        if (Double.MaxValue.Equals(resultado))
                        {
                            Label label = lblResultado;
                            label.IsVisible = true;
                        }
                        else
                        {
                            resultado = Math.Pow(numero1, numero2);
                        }
                        break;   
                }
                lblResultado.Text = "El resultado es: " + resultado.ToString();
            }
            else
            {
                lblResultado.Text = "Ingrese números válidos en ambos campos.";
            }
        }
    }
    public enum Operacion
    {
        Suma = 1,
        Resta = 2,
        Multiplicacion = 3,
        Division = 4,
        Potenciacion = 5,
    }
}