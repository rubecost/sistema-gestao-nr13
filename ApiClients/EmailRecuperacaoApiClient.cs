using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.ApiClients
{
	public class EmailRecuperacaoApiClient
	{
		private readonly HttpClient _client;

		public EmailRecuperacaoApiClient()
		{
			_client = new HttpClient();
		}

		public async Task<string> RecuperarSenhaAsync(string email)
		{
			try
			{
				var emailRequest = new { Email = email };

				var response = await _client.PostAsync("https://localhost:7037/api/login/email_recuperacao", JsonContent.Create(emailRequest));

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<ApiResponse>(content);
					return result?.Message ?? "Erro ao processar a resposta.";
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
				return "Erro de rede.";
			}
			catch (Exception)
			{
				return "Erro inesperado";
			}
		}
	}
	public class ApiResponse
	{
		public string? Message { get; set; }
		public TokenResponse? Token { get; set; }
	}
	public class TokenResponse
	{
		public string? Token { get; set; }
	}
}
