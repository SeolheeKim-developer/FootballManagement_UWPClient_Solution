using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManagement_UWPClient.Models
{
    public class Team
    {
        public string Player
        {
            get
            {
                return " " + Players.Count.ToString() + " Players in this team";
            }
        }
        public string BudgetText
        {
            get
            {
                return "Budget: " + Budget.ToString() + "," ;
            }
        }
        
        public int ID { get; set; }
        public string Name { get; set; }

        public double Budget { get; set; }


        public string  LeagueCode { get; set; }
        public League League { get; set; }


        public ICollection<Player> Players { get; set; } = new HashSet<Player>();

        //public int? NumberOfPlayers { get; set; } = null;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {

            if (Name[0] == 'X' || Name[0] == 'F' || Name[0] == 'S')
            {
                yield return new ValidationResult("Team names are not allowed to start with the letters X, F, or S.", new[] { "Name" });
            }
        }
    }
}
