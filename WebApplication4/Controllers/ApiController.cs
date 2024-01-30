using Microsoft.AspNetCore.Mvc;
using System;
using System.Text.Json;

namespace WebApplication4.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogApiController : ControllerBase
    {
       
        [HttpGet(Name = "ApiController")]
        public async Task<IActionResult> PerformSearch(string searchTerm)
        {
            bool isAppropriate = CheckAppropriateness(searchTerm);
            if (!isAppropriate)
            {
                return BadRequest(new { Message = "Invalid search Term." });
            }

            string ApiKey = "AIzaSyCJliVyqGoNRpVN_5hJ491EG5QUPwoAua4";
            string SearchEngineId = "7441ce6c6fb45452a";

            using (HttpClient client = new HttpClient())
            {
                string apiUrl = $"https://www.googleapis.com/customsearch/v1?q={searchTerm}&key={ApiKey}&cx={SearchEngineId}";

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                Console.WriteLine(response.Content);

                if (response.IsSuccessStatusCode)
                {
                    var searchResponse  = await response.Content.ReadAsStringAsync();
                    return Ok(new { Message = "Search request processed successfully.", searchResponse });
                }
                else
                {
                    return StatusCode((int)response.StatusCode, new { Message = "Error processing search request." });
                }
            }
        }

        private bool CheckAppropriateness(string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm) || searchTerm.Length < 3 || searchTerm.Length > 50)
            {
                return false;
            }

            return true;
        }

        private bool ContainsProfanity(string text)
        {
            return false;
        }
    }
}
