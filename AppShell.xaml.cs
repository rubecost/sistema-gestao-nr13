﻿using Cronos.Views;

namespace Cronos
{
	public partial class AppShell : Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
			//Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
		}
	}
}
