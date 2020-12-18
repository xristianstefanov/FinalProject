namespace LeagueOfLegendsChampions.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using LeagueOfLegendsChampions.Data;
    using LeagueOfLegendsChampions.Data.Common.Repositories;
    using LeagueOfLegendsChampions.Data.Models;
    using LeagueOfLegendsChampions.Data.Repositories;
    using LeagueOfLegendsChampions.Services.Mapping;
    using Microsoft.EntityFrameworkCore;
    using Moq;
    using Xunit;

    public class SkillsServiceTests
    {
        public class MyTestSkillGetAll : IMapFrom<Skill>
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string SkillImageUrl { get; set; }
        }

        [Fact]
        public async Task SkillsGetAllMethodShouldWorkCorrect()
        {
            var listOfSkills = new List<Skill> { new Skill { Id = "1", Name = "FirstSkill", ChampionId = "1" } };

            var mockRepoSkill = new Mock<IDeletableEntityRepository<Skill>>();
            mockRepoSkill.Setup(x => x.AllAsNoTracking()).Returns(listOfSkills.AsQueryable());
            mockRepoSkill.Setup(x => x.AddAsync(It.IsAny<Skill>())).Callback(
                (Skill skill) => listOfSkills.Add(skill));

            var skillsService = new SkillsService(mockRepoSkill.Object);
            AutoMapperConfig.RegisterMappings(typeof(MyTestSkillGetAll).Assembly);

            var allSkills = skillsService.GetAll<MyTestSkillGetAll>("1");

            Assert.Equal(1, allSkills.Count());
        }
    }
}
