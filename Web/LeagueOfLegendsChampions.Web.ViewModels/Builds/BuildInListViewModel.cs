namespace LeagueOfLegendsChampions.Web.ViewModels.Builds
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using AutoMapper;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;
    using LeagueOfLegendsChampions.Web.ViewModels.Items;

    public class BuildInListViewModel : IMapFrom<Build>
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        public ApplicationUser User { get; set; }
        public IEnumerable<ItemInBuildViewModel> BuildItems { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public List<string> SelectedItems { get; set; }
    }
}
