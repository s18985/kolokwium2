﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.Models
{
    public class Team
    {

        public int IdTeam { get; set; }
        public string TeamName { get; set; }
        public int MaxAge { get; set; }

        public ICollection<ChampionshipTeam> ChampionshipTeams { get; set; }
        public ICollection<PlayerTeam> PlayerTeams { get; set; }
    }
}
