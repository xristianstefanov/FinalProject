namespace LeagueOfLegendsChampions.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Data;
    using LeagueOfLegendsChampions.Web.ViewModels.Builds;
    using LeagueOfLegendsChampions.Web.ViewModels.Champions;
    using LeagueOfLegendsChampions.Web.ViewModels.Items;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class BuildsController : Controller
    {
        private readonly IBuildsService buildsService;
        private readonly IChampionsService championsService;
        private readonly IItemsService itemsService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IDeletableEntityRepository<Item> itemsRepository;
        private readonly IRepository<BuildItem> buildItemsRepository;
        public BuildsController(IBuildsService buildsService, IChampionsService championsService, IItemsService itemsService, UserManager<ApplicationUser> userManager, IDeletableEntityRepository<Item> itemsRepository, IRepository<BuildItem> buildItemsRepository)
        {
            this.buildsService = buildsService;
            this.championsService = championsService;
            this.itemsService = itemsService;
            this.userManager = userManager;
            this.itemsRepository = itemsRepository;
            this.buildItemsRepository = buildItemsRepository;
        }

        public IActionResult All(string id)
        {
            var currentChampion = this.championsService.GetById<ChampionInListViewModel>(id);

            var viewModel = new BuildsListViewModel
            {
                Id = id,
                ChampionName = currentChampion.Name,
                Builds = this.buildsService.GetAll<BuildInListViewModel>(id),
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<Item> listOfItemsToUse = this.itemsRepository.AllAsNoTracking().ToList();
            var viewModel = new BuildInListViewModel();
            viewModel.Items = listOfItemsToUse;
            viewModel.SelectedItems = new List<string> { "1", "2", "3", "4", "5", "6" };
            int count = 0;
            foreach (var item in viewModel.Items)
            {
                item.Id = $"{count + 1}";
                count++;
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(BuildInListViewModel input, string id)
        {
            var user = await this.userManager.GetUserAsync(this.User);
            input.User = user;
            await this.buildsService.CreateAsync(input, id);
            return this.Redirect($"/Champions/ById/{id}");
        }
    }
}
