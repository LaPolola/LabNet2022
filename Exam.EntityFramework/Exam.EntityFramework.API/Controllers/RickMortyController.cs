using Exam.EntityFramework.API.Models.Dto;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Exam.EntityFramework.API.Controllers
{
    [EnableCors(origins: "https://localhost:44337,https://localhost:44338", headers: "*", methods: "*")]
    public class RickMortyController : ApiController
    {
        // GET: RickMorty
        public async Task<List<RickMortyApiCharacter>> GetCharacters()
        {
            var httpClient = new HttpClient();
            var json = await httpClient.GetStringAsync("https://rickandmortyapi.com/api/character");
            var characters = JsonConvert.DeserializeObject<RickMortyApiDto>(json);
            return characters.Results;
        }
    }
}