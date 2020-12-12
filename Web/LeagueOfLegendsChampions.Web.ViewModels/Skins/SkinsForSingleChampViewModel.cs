namespace LeagueOfLegendsChampions.Web.ViewModels.Skins
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SkinsForSingleChampViewModel
    {
        public string ChampionName { get; set; }
        public IEnumerable<SingleSkinViewModel> Skins { get; set; }
    }
}
