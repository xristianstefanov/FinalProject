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
            this.Skills = new HashSet<string>();
        }

        public ICollection<string> Skills { get; set; }

        [Required]
        [ForeignKey(nameof(Models.Champion))]
        public string ChampionId { get; set; }
        public virtual Champion Champion { get; set; }
    }
}
