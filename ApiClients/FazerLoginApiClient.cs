using Cronos.Views;
using Newtonsoft.Json;
using System;
using Cronos.Services;
using Cronos.ApiClients;
using System.Net.Http.Json;
using CommunityToolkit.Mvvm.Messaging;

namespace Cronos.ApiClients
{
	public class FazerLoginApiClient
	{
		private readonly HttpClient _client;
		public FazerLoginApiClient()
		{
			_client = new HttpClient();
		}
		public async Task<string> FazerLoginAsync(string email, string senha)
		{
			try
			{
				var loginRequest = new { Email = email, Senha = senha };

				var response = await _client.PostAsJsonAsync("https://localhost:7037/api/login/autenticacao", loginRequest);

				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();

					var result = JsonConvert.DeserializeObject<ApiResponse>(content);

					if (result != null && result.Token != null)
					{
						await SecureStorage.SetAsync("KeyToken", result.Token.Token ?? "");

						if (Application.Current != null)
						{
							Application.Current.MainPage = new MainPage();
						}

						return result.Message ?? "Resposta sem mensagem.";
					}

					return "Resposta malformada.";
				}
				else
				{
					var content = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<ApiResponse>(content);
					return result?.Message ?? "Erro ao processar a resposta.";
				}
			}
			catch (HttpRequestException)
			{
				WeakReferenceMessenger.Default.Send(new MensageriaService("NoWifi"));
				return ""; 
			}
			catch (Exception)
			{
				return "Erro desconhecido tente novamente!";
			}
		}
	}
}