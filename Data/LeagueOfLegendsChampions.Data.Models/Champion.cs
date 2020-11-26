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

        public string ImageIconUrl { get; set; }
        public string ImageFullSizeUrl { get; set; }

        public string Name { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<ChampionRole> ChampionRoles { get; set; }

        public virtual ICollection<Build> Builds { get; set; }

        public virtual ICollection<Rune> Runes { get; set; }

        public virtual ICollection<SkillsSet> SkillsSets { get; set; }

    }
}
