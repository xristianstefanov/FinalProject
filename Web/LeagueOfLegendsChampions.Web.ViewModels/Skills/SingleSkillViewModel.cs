namespace LeagueOfLegendsChampions.Web.ViewModels.Skills
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class SingleSkillViewModel : IMapFrom<Skill>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string SkillImageUrl { get; set; }
        public int FirstLevelToUpgrade { get; set; }
        public int SecondLevelToUpgrade { get; set; }
        public int ThirdLevelToUpgrade { get; set; }
        public int FourthLevelToUpgrade { get; set; }
        public int FifthLevelToUpgrade { get; set; }
    }
}
