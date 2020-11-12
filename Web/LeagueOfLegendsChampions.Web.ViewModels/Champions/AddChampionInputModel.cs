namespace LeagueOfLegendsChampions.Web.ViewModels.Champions
{
    using System.ComponentModel.DataAnnotations;
    public class AddChampionInputModel
    {
        [Required]
        [MinLength(30)]
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
