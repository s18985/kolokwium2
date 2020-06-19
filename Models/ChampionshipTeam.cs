namespace kolokwium2.Models
{
    public class ChampionshipTeam
    {
        public int IdChampionship { get; set; }
        public int IdTeam { get; set; }
        public float? Score { get; set; }

        public Championship Championship { get; set; }
        public Team Team { get; set; }

    }
}