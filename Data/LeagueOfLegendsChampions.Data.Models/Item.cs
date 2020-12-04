namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using LeagueOfLegendsChampions.Data.Common.Models;
    public class Item : BaseDeletableModel<string>
    {
        public Item()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Builds = new HashSet<BuildItem>();
        }

        public string Name { get; set; }

        public string ImageUrl { get; set; }

        public ICollection<BuildItem> Builds { get; set; }
    }
}
