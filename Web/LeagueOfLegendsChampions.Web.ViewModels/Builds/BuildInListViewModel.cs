namespace LeagueOfLegendsChampions.Web.ViewModels.Builds
{
    using System.Collections.Generic;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;
    using LeagueOfLegendsChampions.Web.ViewModels.Items;

    public class BuildInListViewModel : IMapFrom<Build>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<ItemInBuildViewModel> Items { get; set; }
        public IEnumerable<string> SelectedItems { get; set; }
    }
}
