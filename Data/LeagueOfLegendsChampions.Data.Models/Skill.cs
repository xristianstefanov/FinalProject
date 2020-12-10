namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LeagueOfLegendsChampions.Data.Common.Models;
    public class Skill : BaseDeletableModel<string>
    {
        public Skill()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }
        public string SkillImageUrl { get; set; }
        public int FirstLevelToUpgrade { get; set; }
        public int SecondLevelToUpgrade { get; set; }
        public int ThirdLevelToUpgrade { get; set; }
        public int FourthLevelToUpgrade { get; set; }
        public int FifthLevelToUpgrade { get; set; }
        public string ChampionId { get; set; }
        public virtual Champion Champion { get; set; }
    }
}
