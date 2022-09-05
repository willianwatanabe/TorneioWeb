using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TorneioWeb.Models;
using TorneioWeb.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace TorneioWeb.Controllers
{
    public class TournamentController : Controller
    {
        private readonly IFighterRepository _fighterRepository;
        private readonly ITournamentRepository _tournamentRepository;

        public TournamentController(IFighterRepository fighterRepository, ITournamentRepository tournamentRepository)
        {
            _fighterRepository = fighterRepository;
            _tournamentRepository = tournamentRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            var fighters = _fighterRepository.GetListOfFighters();
            return View(fighters);
        }

        public IActionResult Tournament()
        {
            var fighters = _fighterRepository.GetListOfFighters();
            return View(fighters);
        }

        [HttpPost]
        public IActionResult StartTournament(IFormCollection fighters)
        {
            List<FighterModel> lutadoresSelecionados = _fighterRepository.GetFightersById(fighters);

            List<FighterModel> listaLutadoresOrganizadoPorIdade = _tournamentRepository.OrderByAge(lutadoresSelecionados);
            var resultado = _tournamentRepository.GetWinnerTournament(listaLutadoresOrganizadoPorIdade);

            return View("Winner", resultado);
        }

        public IActionResult Winner(int id)
        {
            return View(_fighterRepository.GetFightersById(id));
        }

    }
}
