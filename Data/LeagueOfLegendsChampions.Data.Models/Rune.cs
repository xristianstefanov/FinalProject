namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LeagueOfLegendsChampions.Data.Common.Models;
    public class Rune : BaseDeletableModel<string>
    {
        public Rune()
        {
            this.Id = Guid.NewGuid().ToString();
            this.RuneParts = new HashSet<RunePart>();
        }

        [Required]
        public string Name { get; set; }
        public ICollection<RunePart> RuneParts { get; set; }

        [Required]
        [ForeignKey(nameof(Models.Champion))]
        public string ChampionId { get; set; }
        public virtual Champion Champion { get; set; }
    }
}
