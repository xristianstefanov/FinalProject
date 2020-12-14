namespace LeagueOfLegendsChampions.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LeagueOfLegendsChampions.Services.Data;
    using LeagueOfLegendsChampions.Web.ViewModels.Champions;
    using LeagueOfLegendsChampions.Web.ViewModels.Runes;
    using Microsoft.AspNetCore.Mvc;

    public class RunesController : Controller
    {
        private readonly IRunesService runesService;
        private readonly IChampionsService championsService;

        public RunesController(IRunesService runesService, IChampionsService championsService)
        {
            this.runesService = runesService;
            this.championsService = championsService;
        }

        public IActionResult All(string id)
        {
            var currentChampion = this.championsService.GetById<ChampionInListViewModel>(id);

            var viewModel = new RuneForSingleChampViewModel
            {
                ChampionName = currentChampion.Name,
                Runes = this.runesService.GetAll<SingleRuneViewModel>(id),
            };

            return this.View(viewModel);
        }
    }
}
