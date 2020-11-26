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
        }

        public string Name { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string ImageUrl { get; set; }

        public string BuildId { get; set; }

        public virtual Build Build { get; set; }
    }
}
