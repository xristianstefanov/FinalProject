namespace LeagueOfLegendsChampions.Data.Models
{
    public class BuildItem
    {
        public string Id { get; set; }
        public string BuildId { get; set; }
        public virtual Build Build { get; set; }
        public string ItemId { get; set; }
        public virtual Item Item { get; set; }
    }
}
