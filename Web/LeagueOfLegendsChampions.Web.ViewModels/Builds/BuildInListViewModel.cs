namespace LeagueOfLegendsChampions.Web.ViewModels.Builds
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;
    using LeagueOfLegendsChampions.Web.ViewModels.Items;

    public class BuildInListViewModel : IMapFrom<Build>
    {
        public string Name { get; set; }

        public ApplicationUser User { get; set; }
        public IEnumerable<ItemInBuildViewModel> BuildItems { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public List<string> SelectedItems { get; set; }
    }
}
