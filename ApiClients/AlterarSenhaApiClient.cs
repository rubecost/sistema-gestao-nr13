﻿using Cronos.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Cronos.ApiClients
{
	public class AlterarSenhaApiClient
	{
		private readonly HttpClient _client;
		public AlterarSenhaApiClient()
		{
			_client = new HttpClient();
		}

		public async Task<string> AlterarSenhaAsync(string email, string novaSenha)
		{
			try
			{
				var token = await SecureStorage.GetAsync("KeyToken");

				if (string.IsNullOrEmpty(token))
				{
					throw new UnauthorizedAccessException("Usuário não autenticado.");
				}

				_client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

				var requestContent = new { Email = email, Senha = novaSenha };

				HttpResponseMessage response = await _client.PostAsJsonAsync("https://localhost:7037/api/login/alterar_senha", requestContent);

				if (response.IsSuccessStatusCode)
				{
					var content = await response.Content.ReadAsStringAsync();
					var result = JsonConvert.DeserializeObject<ApiResponse>(content);
					return result?.Message ?? "Senha alterada com sucesso.";
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
}
