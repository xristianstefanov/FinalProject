namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using LeagueOfLegendsChampions.Data.Common.Models;

    public class Champion : BaseDeletableModel<string>
    {
        public Champion()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ChampionRoles = new HashSet<ChampionRole>();
            this.Builds = new HashSet<Build>();
            this.Runes = new HashSet<Rune>();
            this.SkillsSets = new HashSet<SkillsSet>();
        }

        [Required]

        public string ImageUrl { get; set; }

        [Required]

        public string Name { get; set; }

        public virtual ICollection<ChampionRole> ChampionRoles { get; set; }

        public virtual ICollection<Build> Builds { get; set; }

        public virtual ICollection<Rune> Runes { get; set; }

        public virtual ICollection<SkillsSet> SkillsSets { get; set; }

    }
}
