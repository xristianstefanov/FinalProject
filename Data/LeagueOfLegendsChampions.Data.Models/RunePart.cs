namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LeagueOfLegendsChampions.Data.Common.Models;
    public class RunePart : BaseDeletableModel<string>
    {
        public RunePart()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string Name { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ImageUrl { get; set; }
        public string RuneId { get; set; }

        public virtual Rune Rune { get; set; }
    }
}
