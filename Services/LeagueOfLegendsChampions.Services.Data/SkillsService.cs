namespace LeagueOfLegendsChampions.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Services.Mapping;

    public class SkillsService : ISkillsService
    {
        private readonly IDeletableEntityRepository<Skill> skillsRepository;

        public SkillsService(IDeletableEntityRepository<Skill> skillsRepository)
        {
            this.skillsRepository = skillsRepository;
        }

        public IEnumerable<T> GetAll<T>(string id)
        {
            var skills = this.skillsRepository.AllAsNoTracking()
                .OrderBy(s => s.CreatedOn)
                .Where(b => b.ChampionId == id)
                .To<T>()
                .ToList();

            return skills;
        }
    }
}
