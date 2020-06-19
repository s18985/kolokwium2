using kolokwium2.DTOs.Requests;
using kolokwium2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.DAL
{
    public interface IChampionshipDbService
    {
        public Player GetPlayer(int id);

        public ChampionshipTeam UpdateChampionship(int id, UpdateChampionshipRequest request);
    }
}
