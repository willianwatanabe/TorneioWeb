using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioWeb.Models;

namespace TorneioWeb.Repository
{
    public interface ITournamentRepository
    {
        int CalcPercentVictories(FighterModel fighter);
        FighterModel GetWinnerFight(FighterModel fighter1, FighterModel fighter2);
        FighterModel GetWinnerDraw(FighterModel fighter1, FighterModel fighter2);
        FighterModel GetWinnerTournament(List<FighterModel> fighter);
        List<FighterModel> Match(List<FighterModel> fighter);
        List<FighterModel> OrderByAge(List<FighterModel> fighterId);
        FighterModel UpdateFighter(FighterModel winner, FighterModel loser);
    }
}
