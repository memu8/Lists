using System;
using System.IO;
using Xamarin.Forms;

namespace Lists
{
    public partial class App : Application
    {
        static Lists.Data.ToDoDatabase toDoDatabase;

        public static Lists.Data.ToDoDatabase ToDoDatabase
        {
            get
            {
                if (toDoDatabase == null)
                {
                    toDoDatabase = new Lists.Data.ToDoDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ToDo.db3"));
                }
                return toDoDatabase;
            }
        }

        static Lists.Data.ShoppingDatabase shoppingDatabase;

        public static Lists.Data.ShoppingDatabase ShoppingDatabase
        {
            get
            {
                if (shoppingDatabase == null)
                {
                    shoppingDatabase = new Lists.Data.ShoppingDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Shopping.db3"));
                }
                return shoppingDatabase;
            }
        }

        static Lists.Data.GoalsDatabase goalsDatabase;

        public static Lists.Data.GoalsDatabase GoalsDatabase
        {
            get
            {
                if (goalsDatabase == null)
                {
                    goalsDatabase = new Lists.Data.GoalsDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Goals.db3"));
                }
                return goalsDatabase;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
