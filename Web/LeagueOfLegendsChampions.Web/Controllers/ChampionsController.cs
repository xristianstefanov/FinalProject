namespace LeagueOfLegendsChampions.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using LeagueOfLegendsChampions.Web.ViewModels.Champions;
    using Microsoft.AspNetCore.Mvc;

    public class ChampionsController : Controller
    {
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
    }
}
