namespace LeagueOfLegendsChampions.Web.ViewModels.Champions
{
    using System;
    using System.Collections.Generic;
    public class ChampionsListViewModel
    {
        public IEnumerable<ChampionInListViewModel> Champions { get; set; }
    }
}
