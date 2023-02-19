using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagement_UWPClient.Models
{
    public class Player
    {
        public int ID { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Jersey { get; set; }

        public DateTime DOB { get; set; }

        public double FeePaid { get; set; }

        public string EMail { get; set; }


        public Byte[] RowVersion { get; set; }

        public ICollection<Team> Teams { get; set; }
        public int? NumberOfTeams { get; set; } = null;
    }
}
