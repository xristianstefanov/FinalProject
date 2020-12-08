using LeagueOfLegendsChampions.Services.Data;
using LeagueOfLegendsChampions.Web.ViewModels.Builds;
using LeagueOfLegendsChampions.Web.ViewModels.Champions;
using LeagueOfLegendsChampions.Web.ViewModels.Items;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LeagueOfLegendsChampions.Web.Controllers
{
    public class BuildsController : Controller
    {
        private readonly IBuildsService buildsService;
        private readonly IChampionsService championsService;
        public BuildsController(IBuildsService buildsService, IChampionsService championsService)
        {
            this.buildsService = buildsService;
            this.championsService = championsService;
        }

        public IActionResult All(string id)
        {
            var currentChampion = this.championsService.GetById<ChampionInListViewModel>(id);

            var viewModel = new BuildsListViewModel
            {
                ChampionName = currentChampion.Name,
                Builds = this.buildsService.GetAll<BuildInListViewModel>(id),
            };
            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var viewModel = new BuildInListViewModel
            {
                Id = "1",
                Name = "Neshto1",
                Items = new List<ItemInBuildViewModel>
                {
                    new ItemInBuildViewModel {Id = "1", Name = "NqkakuvItem1"},
                    new ItemInBuildViewModel {Id = "2", Name = "NqkakuvItem2"},
                    new ItemInBuildViewModel {Id = "3", Name = "NqkakuvItem3"},
                    new ItemInBuildViewModel {Id = "4", Name = "NqkakuvItem4"},
                    new ItemInBuildViewModel {Id = "5", Name = "NqkakuvItem5"},
                    new ItemInBuildViewModel {Id = "6", Name = "NqkakuvItem6"},
                    new ItemInBuildViewModel {Id = "7", Name = "NqkakuvItem7"},
                },
                SelectedItems = new List<string> { "1", "2", "3", "4", "5", "6"},
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(BuildInListViewModel input)
        {
            // tuk dovavqme nov build kum bazata s propertitata vkarani ot input i sled tova ne vrushtame view a redirect kum All builds
            return this.View();
        }

    }
}
