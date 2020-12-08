using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Polly.Retry;

namespace MicroService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PollyController : ControllerBase
    {
        public readonly RetryPolicy<HttpResponseMessage> _httpRequestPolicy;
        public PollyController()
        {
            _httpRequestPolicy = RetryPolicy.HandleResult<HttpResponseMessage>(r => r.StatusCode == System.Net.HttpStatusCode.InternalServerError).WaitAndRetry(3, retryAttempt => TimeSpan.FromSeconds(retryAttempt));// retryAttempt => TimeSpan.FromSeconds(retryAttempt)
        }
        [Route("get")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var httpClient = new HttpClient();
            string requestEndpoint = "http://localhost:5210/api/Users/GetList";
            string numbers = string.Empty;
            try
            {
                HttpResponseMessage httpResponse = _httpRequestPolicy.Execute(() => { return httpClient.GetAsync(requestEndpoint).Result; });
                numbers = await httpResponse.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return Ok(numbers);
        }
    }
}
