namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class SkinsService : ISkinsService
    {
        private readonly IDeletableEntityRepository<Skin> skinsRepository;

        public SkinsService(IDeletableEntityRepository<Skin> skinsRepository)
        {
            this.skinsRepository = skinsRepository;
        }

        public IEnumerable<T> GetAll<T>(string id)
        {
            var skins = this.skinsRepository.AllAsNoTracking()
                .OrderBy(s => s.CreatedOn)
                .Where(b => b.ChampionId == id)
                .To<T>()
                .ToList();

            return skins;
        }
    }
}
