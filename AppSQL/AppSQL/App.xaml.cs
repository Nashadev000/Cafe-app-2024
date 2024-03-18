using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppSQL
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Listados.Listado_Tipos());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
