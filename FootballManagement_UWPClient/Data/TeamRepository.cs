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
    public class TeamRepository : ITeamRepository
    {
        private readonly HttpClient client = new HttpClient();

        public TeamRepository()
        {
            client.BaseAddress = Jeeves.DBUri;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<Team> GetTeam(int ID)
        {
            HttpResponseMessage response = await client.GetAsync($"api/teams/{ID}");
            if (response.IsSuccessStatusCode)
            {
                Team team = await response.Content.ReadAsAsync<Team>();
                return team;
            }
            else
            {
                throw new Exception("Could not access that Team.");
            }
        }

        public async Task<List<Team>> GetTeamByLeague(string LeagueCode)
        {
            HttpResponseMessage response = await client.GetAsync($"api/Teams/ByLeague/{LeagueCode}");
            if (response.IsSuccessStatusCode)
            {
                List<Team> Teams = await response.Content.ReadAsAsync<List<Team>>();
                return Teams;
            }
            else
            {
                throw new Exception("Could not access the list of Teams by League.");
            }
        }

        public async Task<List<Team>> GetTeams()
        {
            HttpResponseMessage response = await client.GetAsync("api/teams/inc");
            if (response.IsSuccessStatusCode)
            {
                List<Team> teams = await response.Content.ReadAsAsync<List<Team>>();
                return teams;
            }
            else
            {
                throw new Exception("Could not access the list of Leagues.");
            }
        }

        public async Task UpdateTeam(Team teamToUpdate)
        {
            var response = await client.PutAsJsonAsync($"/api/Teams/{teamToUpdate.ID}", teamToUpdate);
            if (!response.IsSuccessStatusCode)
            {
                var ex = Jeeves.CreateApiException(response);
                throw ex;
            }
        }

        public async Task AddTeam(Team teamToAdd)
        {
            var response = await client.PostAsJsonAsync("/api/Teams", teamToAdd);
            if (!response.IsSuccessStatusCode)
            {
                var ex = Jeeves.CreateApiException(response);
                throw ex;
            }
        }

        public async Task DeleteTeam(Team teamToDelete)
        {
            var response = await client.DeleteAsync($"/api/Teams/{teamToDelete.ID}");
            if (!response.IsSuccessStatusCode)
            {
                var ex = Jeeves.CreateApiException(response);
                throw ex;
            }
        }

    }
}
