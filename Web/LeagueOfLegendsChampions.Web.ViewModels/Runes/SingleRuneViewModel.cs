namespace LeagueOfLegendsChampions.Web.ViewModels.Runes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class SingleRuneViewModel : IMapFrom<Rune>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string RuneImgUrl { get; set; }
    }
}
