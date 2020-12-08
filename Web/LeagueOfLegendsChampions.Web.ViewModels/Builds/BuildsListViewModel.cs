namespace LeagueOfLegendsChampions.Web.ViewModels.Builds
{
    using System.Collections.Generic;

    public class BuildsListViewModel
    {
        public string ChampionName { get; set; }
        public IEnumerable<BuildInListViewModel> Builds { get; set; }
    }
}
