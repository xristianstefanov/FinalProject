namespace LeagueOfLegendsChampions.Web.ViewModels.Skills
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SkillsForSingleChampViewModel
    {
        public string ChampionName { get; set; }
        public IEnumerable<SingleSkillViewModel> Skills { get; set; }
    }
}
