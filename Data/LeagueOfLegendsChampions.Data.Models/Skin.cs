namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LeagueOfLegendsChampions.Data.Common.Models;
    public class Skin : BaseDeletableModel<string>
    {
        public Skin()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public string SkinName { get; set; }
        public string SkinImageUrl { get; set; }
        public string ChampionId { get; set; }
        public virtual Champion Champion { get; set; }
    }
}
