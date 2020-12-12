namespace LeagueOfLegendsChampions.Web.ViewModels.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class SingleSkinViewModel : IMapFrom<Skin>
    {
        public string Id { get; set; }
        public string SkinName { get; set; }
        public string SkinImageUrl { get; set; }
    }
}
