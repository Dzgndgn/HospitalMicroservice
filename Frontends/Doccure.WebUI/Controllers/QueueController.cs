using Doccure.WebUI.Dtos.QueueDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Doccure.WebUI.Controllers
{
    public class QueueController : Controller
    {
        private readonly IHttpClientFactory _httpClient;

        public QueueController(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async  Task<IActionResult> Index()
        {
            
            var client = _httpClient.CreateClient();
            var response = await client.GetAsync("https://localhost:7249/api/Queues");
            var responseString = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                return StatusCode(
        (int)response.StatusCode,
        responseString);
            }
            
            var jsonDeserialized = JsonConvert.DeserializeObject<List<ResultPatientQueueDto>>(responseString);
            return View(jsonDeserialized);
        }
    }
}
