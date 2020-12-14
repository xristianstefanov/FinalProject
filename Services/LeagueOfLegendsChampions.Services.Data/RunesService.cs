namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class RunesService : IRunesService
    {
        private readonly IDeletableEntityRepository<Rune> runesRepository;

        public RunesService(IDeletableEntityRepository<Rune> runesRepository)
        {
            this.runesRepository = runesRepository;
        }

        public IEnumerable<T> GetAll<T>(string id)
        {
            var runes = this.runesRepository.AllAsNoTracking()
                .OrderBy(s => s.CreatedOn)
                .Where(b => b.ChampionId == id)
                .To<T>()
                .ToList();

            return runes;
        }
    }
}
