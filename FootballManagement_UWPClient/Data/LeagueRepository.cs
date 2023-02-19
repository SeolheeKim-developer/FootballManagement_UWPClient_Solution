using FootballManagement_UWPClient.Models;
using FootballManagement_UWPClient.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagement_UWPClient.Data
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly HttpClient client = new HttpClient();

        public LeagueRepository()
        {
            client.BaseAddress = Jeeves.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public async Task<League> GetLeague(string code)
        {
            HttpResponseMessage response = await client.GetAsync($"api/Leagues/{code}");
            if (response.IsSuccessStatusCode)
            {
                League leagues = await response.Content.ReadAsAsync<League>();
                return leagues;
            }
            else
            {
                throw new Exception("Could not access the list of Leagues.");
            }
        }

        public async Task<List<League>> GetLeagues()
        {
            HttpResponseMessage response = await client.GetAsync("api/Leagues");
            if (response.IsSuccessStatusCode)
            {
                List<League> leagues = await response.Content.ReadAsAsync<List<League>>();
                return leagues;
            }
            else
            {
                throw new Exception("Could not access the list of Leagues.");
            }
        }

        public Task<List<League>> GetLeaguesInc(string code)
        {
            throw new NotImplementedException();
        }
    }
}
