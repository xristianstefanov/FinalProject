namespace LeagueOfLegendsChampions.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BuildItem
    {
        public string Id { get; set; }
        public string BuildId { get; set; }
        public virtual Build Build { get; set; }
        public string ItemId { get; set; }
        public virtual Item Item { get; set; }

        public string ItemName { get; set; }
        public string ItemImageUrl { get; set; }
    }
}
