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

    public class RunesServiceTests
    {
        public class MyTestRuneGetAll : IMapFrom<Rune>
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string RuneImgUrl { get; set; }
        }

        [Fact]
        public async Task RunesGetAllMethodShouldWorkCorrect()
        {
            var listOfRunes = new List<Rune> { new Rune { Id = "1", Name = "FirstRune", ChampionId = "1" } };

            var mockRepoRune = new Mock<IDeletableEntityRepository<Rune>>();
            mockRepoRune.Setup(x => x.AllAsNoTracking()).Returns(listOfRunes.AsQueryable());
            mockRepoRune.Setup(x => x.AddAsync(It.IsAny<Rune>())).Callback(
                (Rune rune) => listOfRunes.Add(rune));

            var runesService = new RunesService(mockRepoRune.Object);
            AutoMapperConfig.RegisterMappings(typeof(MyTestRuneGetAll).Assembly);

            var allRunes = runesService.GetAll<MyTestRuneGetAll>("1");

            Assert.Equal(1, allRunes.Count());
        }
    }
}
