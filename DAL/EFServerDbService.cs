using kolokwium2.DTOs.Requests;
using kolokwium2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwium2.DAL
{
    public class EFServerDbService : IChampionshipDbService
    {
        private ChampionshipDbContext _context;

        public EFServerDbService(ChampionshipDbContext context)
        {
            _context = context;
        }

        public Player GetPlayer(int id)
        {
            if (_context.Player.FirstOrDefault(x => x.IdPlayer == id) != null)
            {
                var player = _context.Player.Include(x => x.PlayerTeams).ThenInclude(x => x.Team).First();
                return player;
            }
            else
            {
                return null;
            }
        }

        public ChampionshipTeam UpdateChampionship(int id, UpdateChampionshipRequest request)
        {
            List<TeamScoreDTO> teams = new List<TeamScoreDTO>(request.teamScores);

            foreach (TeamScoreDTO t in teams)
            {

                var a = _context.Team.FirstOrDefault(x => x.IdTeam == t.idTeam);
                if (a == null)
                {
                    return null;
                }
                else
                {
                    var updated = new ChampionshipTeam
                    {
                        IdTeam = t.idTeam,
                        IdChampionship = id,
                        Score = t.Score
                    };

                    return updated;
                }
            }
            return null;
        }
    }
}
