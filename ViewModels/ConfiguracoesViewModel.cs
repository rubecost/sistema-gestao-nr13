using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Cronos.Bases;
using Cronos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Cronos.ViewModels
{
	internal class ConfiguracoesViewModel : ObservableObject
	{
		#region VARIAVEIS 
		private string? _CorTema;
		private Button? _backgroundBtn;
		#endregion
		#region CONSTRUTOR
		public ConfiguracoesViewModel()
		{
			CorTemaButtons();
			BackgroundBtn = new Button { BackgroundColor = Color.FromArgb(CorTemaButtons()) };
		}
		#endregion
		#region OBJETOS
		public string? CorTema
		{
			get => _CorTema ??= string.Empty;
			private set => SetProperty(ref _CorTema, value);
		}
		public Button BackgroundBtn
		{
			get => _backgroundBtn ??= new Button();
			set => SetProperty(ref _backgroundBtn, value);
		}
		#endregion
		#region PROCESSOS               
		private string CorTemaButtons()
		{
			bool hasKey = Preferences.Default.ContainsKey("KeyBtnColor");

			if (hasKey)
			{
				CorTema = Preferences.Default.Get("KeyBtnColor", "");
			}
			else
			{
				CorTema = "EB9C25";
			}

			return CorTema;
		}
		private void NovaCorTemaButtons(string hexcor)
		{
			Preferences.Default.Set("KeyBtnColor", hexcor);

			WeakReferenceMessenger.Default.Send(new MensageriaService("BtnPage7"));
		}
		private void RedefinirCorPadrao()
		{
			bool hasKey = Preferences.Default.ContainsKey("KeyBtnColor");

			if (hasKey)
			{
				Preferences.Default.Remove("KeyBtnColor");
			}

			WeakReferenceMessenger.Default.Send(new MensageriaService("BtnPage7"));
		}
		#endregion
		#region COMANDOS
		public ICommand Btn_NovaCorTemaButtons => new Command<string>(NovaCorTemaButtons);
		public ICommand Btn_RedefinirCorPadrao => new Command(RedefinirCorPadrao);
		#endregion
	}
}
