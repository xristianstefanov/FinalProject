namespace LeagueOfLegendsChampions.Web.ViewModels.Builds
{
    using System.Collections.Generic;

    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Web.ViewModels.Items;

    public class BuildsListViewModel
    {
        public string Id { get; set; }
        public string ChampionName { get; set; }
        public IEnumerable<BuildInListViewModel> Builds { get; set; }
    }
}
