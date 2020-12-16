namespace LeagueOfLegendsChampions.Web.ViewModels.Items
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class SingleItemViewModel : IMapFrom<Item>
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}
