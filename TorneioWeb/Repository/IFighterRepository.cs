using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioWeb.Models;

namespace TorneioWeb.Repository
{
    public interface IFighterRepository
    {
        List<FighterModel> GetListOfFighters();
        List<FighterModel> GetFightersById(IFormCollection ids);
        FighterModel GetFightersById(int id);
    }
}
