namespace LeagueOfLegendsChampions.Web.Controllers
{
    using LeagueOfLegendsChampions.Services.Data;
    using LeagueOfLegendsChampions.Web.ViewModels.Builds;
    using Microsoft.AspNetCore.Mvc;

    public class BuildsController : Controller
    {
        private readonly IBuildsService buildsService;
        public BuildsController(IBuildsService buildsService)
        {
            this.buildsService = buildsService;
        }

        public IActionResult All(string id)
        {
            var viewModel = new BuildsListViewModel
            {
                Builds = this.buildsService.GetAll<BuildInListViewModel>(id),
            };
            return this.View(viewModel);
        }

        public IActionResult Create() //Primeren view model s 6 itema
        {
            return this.View();
        }
    }
}
