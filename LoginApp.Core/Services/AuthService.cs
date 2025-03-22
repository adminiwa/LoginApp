using LoginApp.Core.Interfaces;
using LoginApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LoginApp.Core.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<LoginResponse> LoginAsync(UserModel user)
        {
            var url = "https://app.agrodexsas.com/ApiApp/AgrdxApi.php";

            var requestPayload = new
            {
                method = "LOGIN",
                usuario = user.User,
                password = user.Password
            };

            var json = JsonSerializer.Serialize(requestPayload);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _httpClient.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var responseText = await response.Content.ReadAsStringAsync();

                    // El backend retorna un JSON que puede ser un string directamente
                    var message = JsonSerializer.Deserialize<string>(responseText);

                    bool isSuccess = message?.ToLower().Contains("exitoso") == true;

                    return new LoginResponse
                    {
                        Success = isSuccess,
                        Message = message ?? "Respuesta vacía"
                    };
                }

                return new LoginResponse
                {
                    Success = false,
                    Message = $"HTTP Error: {response.StatusCode}"
                };
            }
            catch (Exception ex)
            {
                return new LoginResponse
                {
                    Success = false,
                    Message = $"Error de conexión: {ex.Message}"
                };
            }
        }
    }
}
