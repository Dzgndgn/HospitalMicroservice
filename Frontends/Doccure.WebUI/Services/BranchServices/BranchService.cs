using Doccure.WebUI.Dtos.BranchDtos;
using Newtonsoft.Json;
using System.Text;
using System.Text.Unicode;

namespace Doccure.WebUI.Services.BranchServices
{
    public class BranchService : IBranchService
    {
        private readonly HttpClient Ihttpclient;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public BranchService(HttpClient ihttpclient, IHttpContextAccessor httpContextAccessor)
        {
            Ihttpclient = ihttpclient;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task CreateBranch(CreateBranchDto dto)
        {
            await RequestHeaders();
            var jsonData = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var post =  await Ihttpclient.PostAsync($"https://localhost:5000/api/branches", stringContent);
            handleErrorResponse(post);
        }

        public async Task DeleteBranch(string id)
        {
            await RequestHeaders();
            var delete = await Ihttpclient.DeleteAsync($"https://localhost:5000/api/branches/{id}");
            handleErrorResponse(delete);
        }

        public async Task<List<ResultBranchDto>> GetAllBranch()
        {
            await RequestHeaders();

            var response  = await Ihttpclient.GetAsync($"https://localhost:5000/api/branches");
            handleErrorResponse(response);
            var  responseData = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<List<ResultBranchDto>>(responseData);
            if(deserializedData == null)
            {
                throw new Exception("Failed to deserialize response data.");
            }
            return deserializedData;
        }

        public async Task<GetByIdBranchDto> GetByIdBranch(string id)
        {
            await RequestHeaders();
            var response = await Ihttpclient.GetAsync($"https://localhost:5000/api/branches/{id}");
            handleErrorResponse(response);
            var responseData = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetByIdBranchDto>(responseData);
            if(deserializedData == null)
            {
                throw new Exception("Failed to deserialize response data.");
            }
            return deserializedData;
        }

        public async Task UpdateBranch(UpdateBranchDto dto)
        {
            await RequestHeaders();
            var jsonDta = JsonConvert.SerializeObject(dto);
            var stringContent = new StringContent(jsonDta,Encoding.UTF8, "application/json");
            var put = await Ihttpclient.PutAsync($"https://localhost:5000/api/branches", stringContent);
            handleErrorResponse(put);

        }
        private void handleErrorResponse(HttpResponseMessage responseMessage)
        {
           if(responseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                throw new Exception("401");
            }
           if(responseMessage.StatusCode== System.Net.HttpStatusCode.Forbidden)
            {
                throw new Exception("403");
            }
           if(responseMessage.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                throw new Exception("404)");
            }
           if(responseMessage.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("500");
            }
            if (!responseMessage.IsSuccessStatusCode)
            {
                throw new Exception(
       $"API hatası: {(int)responseMessage.StatusCode} " +
       $"({responseMessage.StatusCode})");
            }
        }
        private async Task RequestHeaders()
        {
            var token = _httpContextAccessor.HttpContext.Session.GetString("JwtToken");
            Ihttpclient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }
    }
}
