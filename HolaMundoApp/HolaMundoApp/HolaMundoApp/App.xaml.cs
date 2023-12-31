﻿//using HolaMundoApp.Services;
using HolaMundoApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HolaMundoApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            Startup.Initialize();
            MainPage = new AppShell();
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
