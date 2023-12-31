﻿using HolaMundoApp.ViewModels;
using HolaMundoApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace HolaMundoApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ClientPage), typeof(ClientPage));
            Routing.RegisterRoute(nameof(OfficePage), typeof(OfficePage));
            Routing.RegisterRoute(nameof(ClosestPage), typeof(ClosestPage));

        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
