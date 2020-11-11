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

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [ForeignKey(nameof(Models.SkillsSet))]
        public string SkillsSetId { get; set; }
        public virtual SkillsSet SkillsSet { get; set; }
    }
}
