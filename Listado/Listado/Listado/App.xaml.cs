using Listado.Data;
using Xamarin.Forms;

namespace Listado
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new MainPage())
            {
                BarBackgroundColor = (Color)Current.Resources["primaryGreen"],
                BarTextColor = Color.White
            };

            MainPage = nav;
        }
        static ListadoDatabase database;
        public static ListadoDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new ListadoDatabase();
                }
                return database;
            }
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
