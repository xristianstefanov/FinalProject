namespace LeagueOfLegendsChampions.Web.ViewModels.Items
{
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class ItemInBuildViewModel : IMapFrom<BuildItem>
    {
        public string Id { get; set; }
        public string ItemName { get; set; }
        public string ItemImageUrl { get; set; }
    }
}
