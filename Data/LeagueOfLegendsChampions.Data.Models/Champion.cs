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
            this.Skins = new HashSet<Skin>();
            this.Builds = new HashSet<Build>();
            this.Runes = new HashSet<Rune>();
            this.Skills = new HashSet<Skill>();
        }

        public string ImageIconUrl { get; set; }

        public string ImageFullSizeUrl { get; set; }

        public string Nickname { get; set; }

        public string Name { get; set; }

        public string Lore { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Skin> Skins { get; set; }

        public virtual ICollection<Build> Builds { get; set; }

        public virtual ICollection<Rune> Runes { get; set; }

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
