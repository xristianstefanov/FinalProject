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

    public class ChampionsServiceTests
    {
        public class MyTestChampionGetAll : IMapFrom<Champion>
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        public class MyTestChampionGetById : IMapFrom<Champion>
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }

        [Fact]
        public async Task ChampionsGetAllShouldWorkCorrect()
        {
            var listOfChampions = new List<Champion> { new Champion { Id = "1", Name = "MyChamp" } };

            var mockRepoChampion = new Mock<IDeletableEntityRepository<Champion>>();
            mockRepoChampion.Setup(x => x.AllAsNoTracking()).Returns(listOfChampions.AsQueryable());
            mockRepoChampion.Setup(x => x.AddAsync(It.IsAny<Champion>())).Callback(
                (Champion champion) => listOfChampions.Add(champion));

            var championService = new ChampionsService(mockRepoChampion.Object);
            AutoMapperConfig.RegisterMappings(typeof(MyTestChampionGetAll).Assembly);

            var allChampions = championService.GetAll<MyTestChampionGetAll>();

            Assert.Equal(1, allChampions.Count());
        }

        [Fact]
        public async Task TaskChampionsGetByIdShouldWorkCorrect()
        {
            var listOfChampions = new List<Champion> { new Champion { Id = "1", Name = "MyChamp" } };

            var mockRepoChampion = new Mock<IDeletableEntityRepository<Champion>>();
            mockRepoChampion.Setup(x => x.AllAsNoTracking()).Returns(listOfChampions.AsQueryable());
            mockRepoChampion.Setup(x => x.AddAsync(It.IsAny<Champion>())).Callback(
                (Champion champion) => listOfChampions.Add(champion));

            var championService = new ChampionsService(mockRepoChampion.Object);
            AutoMapperConfig.RegisterMappings(typeof(MyTestChampionGetAll).Assembly);

            var championById = championService.GetById<MyTestChampionGetById>("1");

            Assert.NotNull(championById);
        }
    }
}
