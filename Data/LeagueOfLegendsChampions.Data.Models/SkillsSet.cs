namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LeagueOfLegendsChampions.Data.Common.Models;
    public class SkillsSet : BaseDeletableModel<string>
    {
        public SkillsSet()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Skills = new HashSet<Skill>();
        }

        public ICollection<Skill> Skills { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
        public string ChampionId { get; set; }
        public virtual Champion Champion { get; set; }
    }
}
