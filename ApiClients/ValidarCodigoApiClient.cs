using Newtonsoft.Json;
using Cronos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.ApiClients
{

	public class ValidarCodigoApiClient
	{
		private readonly HttpClient _client;
		public ValidarCodigoApiClient()
		{
			_client = new HttpClient();
		}
		public async Task<string> ValidarCodigoAsync(string email, string codigo)
		{
			try
			{
				var validarRequest = new { Email = email, Codigo = codigo };

				HttpResponseMessage response = await _client.PostAsJsonAsync("https://localhost:7037/api/login/validar_codigo", validarRequest);
				string content = await response.Content.ReadAsStringAsync();

				var result = JsonConvert.DeserializeObject<ApiResponse>(content);

				if (result != null && result.Token != null)
				{
					await SecureStorage.SetAsync("KeyToken", result.Token.Token ?? "");
					return result.Message ?? "Resposta sem mensagem.";
				}

				return "Resposta malformada.";
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

		/*public async Task<string> ValidarCodigoAsync(string email, string codigo)
		{
			var validarRequest = new { Email = email, Codigo = codigo };

			try
			{
				HttpResponseMessage response = await _client.PostAsJsonAsync("https://localhost:7037/api/login/validar_codigo", validarRequest);

				if (response.IsSuccessStatusCode)
				{
					string content = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<ApiResponse>(content);

					if (result != null)
					{
						await SecureStorage.SetAsync("KeyToken", result.Token ?? "");
						return result.Message ?? "Resposta sem mensagem.";
					}

					return "Resposta malformada.";
				}
				else
				{
					string content = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<ApiResponse>(content);
					return result?.Message ?? "Erro ao processar a resposta.";
				}
			}
			catch (HttpRequestException ex)
			{
				// Tratar exceções de comunicação
				return $"Erro de comunicação com a API: {ex.Message}";
			}
			catch (Exception ex)
			{
				// Tratar outras exceções
				return $"Erro inesperado: {ex.Message}";
			}
		}
		*/
	}

}
