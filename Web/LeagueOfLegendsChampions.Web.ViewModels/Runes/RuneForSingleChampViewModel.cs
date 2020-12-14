namespace LeagueOfLegendsChampions.Web.ViewModels.Runes
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RuneForSingleChampViewModel
    {
        public string ChampionName { get; set; }
        public IEnumerable<SingleRuneViewModel> Runes { get; set; }
    }
}
