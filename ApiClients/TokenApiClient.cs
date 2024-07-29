using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.ApiClients
{
	public class TokenApiClient
	{
		private readonly HttpClient _client;
		public TokenApiClient()
		{
			_client = new HttpClient();
		}
		public async Task<bool> VerificarTokenAsync(string token)
		{
			try
			{
				_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var response = await _client.GetAsync("https://localhost:7037/api/login/verificar_token");

				if (response.IsSuccessStatusCode)
				{
					return true; // Token válido
				}
				else
				{
					return false;
				}
			}
			catch (HttpRequestException)
			{			
				return false; // Erro de rede
			}
			catch (Exception)
			{
				return false; // All erro inesperado
			}
		}
	}
}
