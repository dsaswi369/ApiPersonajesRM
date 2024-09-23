using ApiPersonajesRM.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiPersonajes.Controllers
{
    [Route("api/characters")]
    public class CharactersController : Controller
    {
        private HttpClient _httpClient;

        public CharactersController()
        {
            _httpClient = new HttpClient();
        }

        [HttpGet]
        [Route("all")]
        public async Task<Characters> GetAllCharacters(int page)
        {
            try
            {
                Characters characters = null;
                HttpResponseMessage httpResponseMessage = await
                _httpClient.GetAsync($"https://rickandmortyapi.com/api/character?page={page}");
                httpResponseMessage.EnsureSuccessStatusCode();

                string responseBody = await
                    httpResponseMessage.Content.ReadAsStringAsync();

                characters = JsonConvert.DeserializeObject<Characters>(responseBody);

                return characters;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

