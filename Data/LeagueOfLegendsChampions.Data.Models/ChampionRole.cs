namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LeagueOfLegendsChampions.Data.Common.Models;
    public class ChampionRole : BaseDeletableModel<string>
    {
        public ChampionRole()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [Required]
        [MaxLength(10)]
        public string RoleName { get; set; }

        [Required]
        [ForeignKey(nameof(Models.Champion))]
        public string ChampionId { get; set; }
        public virtual Champion Champion { get; set; }
    }
}
