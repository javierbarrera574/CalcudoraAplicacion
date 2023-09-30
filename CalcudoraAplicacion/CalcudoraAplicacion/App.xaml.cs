using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace CalcudoraAplicacion
{
    public partial class App : Application
    {
        protected Operacion operacion;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage(operacion);
        }
        protected override void OnStart() { }
        protected override void OnSleep() { }
        protected override void OnResume() { }
       
    }
}
