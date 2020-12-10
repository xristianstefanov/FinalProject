namespace LeagueOfLegendsChampions.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LeagueOfLegendsChampions.Services.Data;
    using LeagueOfLegendsChampions.Web.ViewModels.Champions;
    using LeagueOfLegendsChampions.Web.ViewModels.Skills;
    using Microsoft.AspNetCore.Mvc;

    public class SkillsController : Controller
    {
        private readonly ISkillsService skillsService;
        private readonly IChampionsService championsService;
        public SkillsController(ISkillsService skillsService, IChampionsService championsService)
        {
            this.skillsService = skillsService;
            this.championsService = championsService;
        }

        public IActionResult All(string id)
        {
            var currentChampion = this.championsService.GetById<ChampionInListViewModel>(id);

            var viewModel = new SkillsForSingleChampViewModel
            {
                ChampionName = currentChampion.Name,
                Skills = this.skillsService.GetAll<SingleSkillViewModel>(id),
            };

            return this.View(viewModel);
        }
    }
}
