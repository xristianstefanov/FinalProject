namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;
    using LeagueOfLegendsChampions.Web.ViewModels.Champions;

    public class ChampionsService : IChampionsService
    {
        private readonly IDeletableEntityRepository<Champion> championsRepository;

        public ChampionsService(IDeletableEntityRepository<Champion> championsRepository)
        {
            this.championsRepository = championsRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var champions = this.championsRepository.AllAsNoTracking()
               .OrderBy(c => c.Name)
               .To<T>()
               .ToList();

            return champions;
        }

        public T GetById<T>(string id)
        {
            var champion = this.championsRepository.AllAsNoTracking()
                .Where(x => x.Id == id)
                .To<T>().FirstOrDefault();

            return champion;
        }
    }
}
