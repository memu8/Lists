using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using Lists.Views;

namespace Lists
{
    public partial class AppShell : Shell
    {
        Dictionary<string, Type> routes = new Dictionary<string, Type>();
        public Dictionary<string, Type> Routes { get { return routes; } }

        public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

        public AppShell()
        {
            InitializeComponent();
            RegisterRoutes();
            BindingContext = this;
        }

        void RegisterRoutes()
        {
            routes.Add("todoentry", typeof(Lists.Views.ToDoEntryPage));
            routes.Add("shoppingentry", typeof(Lists.Views.ShoppingEntryPage));
            routes.Add("goalsentry", typeof(Lists.Views.GoalsEntryPage));

            foreach (var item in routes)
            {
                Routing.RegisterRoute(item.Key, item.Value);
            }
        }

        void OnNavigating(object sender, ShellNavigatingEventArgs e)
        {
            // Cancel any back navigation
            //if (e.Source == ShellNavigationSource.Pop)
            //{
            //    e.Cancel();
            //}
        }

        void OnNavigated(object sender, ShellNavigatedEventArgs e)
        {
        }
    }
}
