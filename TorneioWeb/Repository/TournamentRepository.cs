using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioWeb.Models;
using System.Data;
using TorneioWeb.Data;
using Microsoft.EntityFrameworkCore;

namespace TorneioWeb.Repository
{
    public class TournamentRepository : ITournamentRepository
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly BancoContext _bancoContex;

        public TournamentRepository(IFighterRepository fighterRepository, BancoContext bancoContext)
        {
            _fighterRepository = fighterRepository;
            _bancoContex = bancoContext;
        }

        public int CalcPercentVictories(FighterModel fighter)
        {
            int pVictories = 100 * fighter.QtyVictories / fighter.QtyFights;
            return pVictories;
        }

        public FighterModel GetWinnerFight(FighterModel fighter1, FighterModel fighter2)
        {
            var pFighter1 = CalcPercentVictories(fighter1);
            var pFighter2 = CalcPercentVictories(fighter2);

            if (pFighter1 == pFighter2)
                return GetWinnerDraw(fighter1, fighter2);

            if (pFighter1 > pFighter2)
                return UpdateFighter(fighter1, fighter2);
            else
                return UpdateFighter(fighter2, fighter1);
        }

        public FighterModel GetWinnerDraw(FighterModel fighter1, FighterModel fighter2)
        {
            if (fighter1.QtyMartialArts > fighter2.QtyMartialArts)
                return UpdateFighter(fighter1, fighter2);

            else if (fighter1.QtyMartialArts < fighter2.QtyMartialArts)
                return UpdateFighter(fighter2, fighter1);

            else if (fighter1.QtyVictories > fighter2.QtyVictories)
                return UpdateFighter(fighter1, fighter2);

            else
                return UpdateFighter(fighter2, fighter1);
        }

        public FighterModel GetWinnerTournament(List<FighterModel> fighter)
        {
            List<FighterModel> winnersOfMatch = fighter;

            for (int i = 0; i < 4; i++)
            {
                winnersOfMatch = Match(winnersOfMatch);
            }

            var winner = winnersOfMatch.FirstOrDefault();

            return winner;

        }

        public List<FighterModel> Match(List<FighterModel> fighter)
        {
            var winners = new List<FighterModel>();
            int index = 0;

            while (index < fighter.Count)
            {
                var winner = GetWinnerFight(fighter[index], fighter[index + 1]);
                winners.Add(winner);
                index += 2;
            }

            return winners;
        }

        public List<FighterModel> OrderByAge(List<FighterModel> fighterId)
        {
            List<FighterModel> listByAge = fighterId.OrderBy(x => x.Age).ToList();
            return listByAge;
        }

        public FighterModel UpdateFighter(FighterModel winner, FighterModel loser)
        {
            winner.QtyFights++;
            winner.QtyVictories++;

            loser.QtyFights++;
            loser.QtyDefeats++;

            _bancoContex.Update(winner);
            _bancoContex.Update(loser);

            _bancoContex.SaveChanges();

            return winner;
        }
    }
}
