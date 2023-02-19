using FootballManagement_UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagement_UWPClient.Data
{
    public interface ITeamRepository
    {
        Task<List<Team>> GetTeams();
        Task<Team> GetTeam(int ID);
        Task<List<Team>> GetTeamByLeague(string LeagueCode);
        Task AddTeam(Team teamToAdd);
        Task UpdateTeam(Team teamToUpdate);
        Task DeleteTeam(Team teamToDelete);
    }
}
