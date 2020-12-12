namespace LeagueOfLegendsChampions.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LeagueOfLegendsChampions.Services.Data;
    using LeagueOfLegendsChampions.Web.ViewModels.Champions;
    using LeagueOfLegendsChampions.Web.ViewModels.Skins;
    using Microsoft.AspNetCore.Mvc;

    public class SkinsController : Controller
    {
        private readonly ISkinsService skinsService;
        private readonly IChampionsService championsService;

        public SkinsController(ISkinsService skinsService, IChampionsService championsService)
        {
            this.skinsService = skinsService;
            this.championsService = championsService;
        }

        public IActionResult All(string id)
        {
            var currentChampion = this.championsService.GetById<ChampionInListViewModel>(id);

            var viewModel = new SkinsForSingleChampViewModel
            {
                ChampionName = currentChampion.Name,
                Skins = this.skinsService.GetAll<SingleSkinViewModel>(id),
            };

            return this.View(viewModel);
        }
    }
}
