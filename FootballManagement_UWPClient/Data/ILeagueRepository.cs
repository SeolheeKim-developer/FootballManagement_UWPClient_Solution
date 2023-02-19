using FootballManagement_UWPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagement_UWPClient.Data
{
    public interface ILeagueRepository
    {
        Task<List<League>> GetLeagues();
        Task<League> GetLeague(string code);
        Task<List<League>> GetLeaguesInc(string code);
    }
}
