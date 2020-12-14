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
        }

        public string Name { get; set; }
        public string RuneImgUrl { get; set; }

        public string ChampionId { get; set; }
        public virtual Champion Champion { get; set; }
    }
}
