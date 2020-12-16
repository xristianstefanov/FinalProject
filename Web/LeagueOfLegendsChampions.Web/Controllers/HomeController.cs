namespace LeagueOfLegendsChampions.Web.Controllers
{
    using System.Diagnostics;
    using System.Linq;
    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Data;
    using LeagueOfLegendsChampions.Web.ViewModels;
    using LeagueOfLegendsChampions.Web.ViewModels.Champions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    public class HomeController : BaseController
    {
        private readonly IChampionsService championsService;
        public HomeController(IChampionsService championsService)
        {
            this.championsService = championsService;
        }

        public IActionResult Index()
        {
            var viewModel = new ChampionsListViewModel
            {
                Champions = this.championsService.GetAll<ChampionInListViewModel>(),
            };
            return this.View(viewModel);
        }

        [Authorize]
        public IActionResult Chat()
        {
            return this.View();
        }

        public IActionResult Privacy()
        {
            return this.View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return this.View(
                new ErrorViewModel { RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier });
        }
    }
}
