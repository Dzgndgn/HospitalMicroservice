using Doccure.WebUI.Dtos.LoginDtos;
using NuGet.Common;
using System.Text;
using System.Text.Json;

namespace Doccure.WebUI.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        private readonly HttpClient _httpClient;

        public LoginService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> LoginAsync(LoginDto dto)
        {
            var serializedDto = JsonSerializer.Serialize(dto);
            var content = new StringContent(serializedDto,Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:7191/api/Logins", content);
            var token = await response.Content.ReadAsStringAsync();
            return token;
        }
    }
}
