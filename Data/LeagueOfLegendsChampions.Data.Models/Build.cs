namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LeagueOfLegendsChampions.Data.Common.Models;
    public class Build : BaseDeletableModel<string>
    {
        public Build()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Items = new HashSet<BuildItem>();
        }

        public string Name { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<BuildItem> Items { get; set; }
        public string ChampionId { get; set; }
        public virtual Champion Champion { get; set; }
    }
}
