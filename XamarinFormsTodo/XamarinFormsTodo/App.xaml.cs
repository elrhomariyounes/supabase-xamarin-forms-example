using Xamarin.Forms;
using XamarinFormsTodo.Services;
using XamarinFormsTodo.Views;

namespace XamarinFormsTodo
{
    public partial class App : Application
    {
        static ITodoService _todoService;
        public App()
        {
            InitializeComponent();

            var nav = new NavigationPage(new TodoListPage());
            nav.BarBackgroundColor = (Color)App.Current.Resources["primaryGreen"];
            nav.BarTextColor = Color.White;

            MainPage = nav;
        }

        public static ITodoService TodoService
        {
            get
            {
                if(_todoService == null)
                {
                    _todoService = new TodoService();
                }

                return _todoService;
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
