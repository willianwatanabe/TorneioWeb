using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioWeb.Data;
using TorneioWeb.Models;

namespace TorneioWeb.Repository
{
    public class FighterRepository : IFighterRepository
    {
        private readonly BancoContext _bancoContext;
        private readonly DbSet<FighterModel> _dbset;

        public FighterRepository(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
            _dbset = bancoContext.Set<FighterModel>();
        }

        public List<FighterModel> GetFightersById(IFormCollection ids)
        {
            List<FighterModel> fighters = new List<FighterModel>();

            foreach (var id in ids)
            {
                fighters.Add(_dbset.Find(Convert.ToInt32(id.Key)));
            }

            return fighters;
        }

        public FighterModel GetFightersById(int id)
        {
            return _dbset.Find(id);
        }

        public List<FighterModel> GetListOfFighters()
        {
            return _bancoContext.Fighters.ToList();
        }
    }
}