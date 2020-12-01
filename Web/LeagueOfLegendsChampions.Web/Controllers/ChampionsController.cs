namespace LeagueOfLegendsChampions.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LeagueOfLegendsChampions.Services.Data;
    using LeagueOfLegendsChampions.Web.ViewModels.Champions;
    using Microsoft.AspNetCore.Mvc;

    public class ChampionsController : Controller
    {
        private readonly IChampionScraperService championScraperService;
        private readonly IChampionsService championsService;
        public ChampionsController(IChampionScraperService championScraperService, IChampionsService championsService)
        {
            this.championScraperService = championScraperService;
            this.championsService = championsService;
        }

        public IActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Add(AddChampionInputModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            return this.Redirect("/");
        }

        public async Task<IActionResult> Import()
        {
            await this.championScraperService.ImportChampionsNamesAndIconsAsync();
            return this.Redirect("/");
        }

        public IActionResult ById(string id)
        {
            var champion = this.championsService.GetById<ChampionInListViewModel>(id);
            return this.View(champion);
        }
    }
}
