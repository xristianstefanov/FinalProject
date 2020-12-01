namespace LeagueOfLegendsChampions.Web.ViewModels.Champions
{
    using AutoMapper;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class ChampionInListViewModel : IMapFrom<Champion>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageIconUrl { get; set; }
        public string ImageFullSizeUrl { get; set; }
        public string Nickname { get; set; }
    }
}
