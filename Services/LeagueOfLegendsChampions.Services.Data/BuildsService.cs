namespace LeagueOfLegendsChampions.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class BuildsService : IBuildsService
    {
        private readonly IDeletableEntityRepository<Build> buildsRepository;

        public BuildsService(IDeletableEntityRepository<Build> buildsRepository)
        {
            this.buildsRepository = buildsRepository;
        }

        public IEnumerable<T> GetAll<T>(string id)
        {
            var builds = this.buildsRepository.AllAsNoTracking()
                .Where(b => b.ChampionId == id)
                .To<T>()
                .ToList();

            return builds;
        }
    }
}
