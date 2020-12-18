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

    public class SkinsServiceTests
    {
        public class MyTestSkinGetAll : IMapFrom<Skin>
        {
            public string Id { get; set; }
            public string SkinName { get; set; }
            public string SkinImageUrl { get; set; }
        }

        [Fact]
        public async Task SkinsGetAllMethodShouldWorkCorrect()
        {
            var listOfSkins = new List<Skin> { new Skin { Id = "1", SkinName = "FirstSkin", ChampionId = "1" } };

            var mockRepoSkin = new Mock<IDeletableEntityRepository<Skin>>();
            mockRepoSkin.Setup(x => x.AllAsNoTracking()).Returns(listOfSkins.AsQueryable());
            mockRepoSkin.Setup(x => x.AddAsync(It.IsAny<Skin>())).Callback(
                (Skin skin) => listOfSkins.Add(skin));

            var skinsService = new SkinsService(mockRepoSkin.Object);
            AutoMapperConfig.RegisterMappings(typeof(MyTestSkinGetAll).Assembly);

            var allSkins = skinsService.GetAll<MyTestSkinGetAll>("1");

            Assert.Equal(1, allSkins.Count());
        }
    }
}
