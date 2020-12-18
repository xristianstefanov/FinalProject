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

    public class ItemsServiceTests
    {
        public class MyTestItemAll : IMapFrom<BuildItem>
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string ItemImageUrl { get; set; }
        }

        public class MyTestItemGetByName : IMapFrom<Item>
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string ItemImageUrl { get; set; }
        }

        public class MyTestItemGetById : IMapFrom<Item>
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string ItemImageUrl { get; set; }
        }

        [Fact]
        public async Task ItemsGetAllMethodShouldWorkCorrect()
        {
            var listOfItems = new List<Item> { new Item { Id = "1", Name = "FirstItem", ImageUrl = "None" } };
            var listOfBuilds = new List<Build> { new Build { Id = "1", Name = "FirstBuild" } };
            var listOfBuildItems = new List<BuildItem> { new BuildItem { Id = "1", BuildId = "1", ItemId = "1" } };

            var mockRepoItems = new Mock<IDeletableEntityRepository<Item>>();
            mockRepoItems.Setup(x => x.AllAsNoTracking()).Returns(listOfItems.AsQueryable());
            mockRepoItems.Setup(x => x.AddAsync(It.IsAny<Item>())).Callback(
                (Item item) => listOfItems.Add(item));

            var mockRepoBuilds = new Mock<IDeletableEntityRepository<Build>>();
            mockRepoBuilds.Setup(x => x.AllAsNoTracking()).Returns(listOfBuilds.AsQueryable());
            mockRepoBuilds.Setup(x => x.AddAsync(It.IsAny<Build>())).Callback(
                (Build build) => listOfBuilds.Add(build));

            var mockRepoBuildItems = new Mock<IRepository<BuildItem>>();
            mockRepoBuildItems.Setup(x => x.AllAsNoTracking()).Returns(listOfBuildItems.AsQueryable());
            mockRepoBuildItems.Setup(x => x.AddAsync(It.IsAny<BuildItem>())).Callback(
                (BuildItem buildItem) => listOfBuildItems.Add(buildItem));

            var itemService = new ItemsService(mockRepoBuildItems.Object, mockRepoItems.Object);
            AutoMapperConfig.RegisterMappings(typeof(MyTestItemAll).Assembly);

            var allItems = itemService.GetAll<MyTestItemAll>();

            Assert.Equal(1, allItems.Count());
        }

        [Fact]
        public async Task ItemsGetByNameMethodShouldWorkCoreect()
        {
            var listOfItems = new List<Item> { new Item { Id = "1", Name = "FirstItem", ImageUrl = "None" } };
            var listOfBuilds = new List<Build> { new Build { Id = "1", Name = "FirstBuild" } };
            var listOfBuildItems = new List<BuildItem> { new BuildItem { Id = "1", BuildId = "1", ItemId = "1" } };

            var mockRepoItems = new Mock<IDeletableEntityRepository<Item>>();
            mockRepoItems.Setup(x => x.AllAsNoTracking()).Returns(listOfItems.AsQueryable());
            mockRepoItems.Setup(x => x.AddAsync(It.IsAny<Item>())).Callback(
                (Item item) => listOfItems.Add(item));

            var mockRepoBuilds = new Mock<IDeletableEntityRepository<Build>>();
            mockRepoBuilds.Setup(x => x.AllAsNoTracking()).Returns(listOfBuilds.AsQueryable());
            mockRepoBuilds.Setup(x => x.AddAsync(It.IsAny<Build>())).Callback(
                (Build build) => listOfBuilds.Add(build));

            var mockRepoBuildItems = new Mock<IRepository<BuildItem>>();
            mockRepoBuildItems.Setup(x => x.AllAsNoTracking()).Returns(listOfBuildItems.AsQueryable());
            mockRepoBuildItems.Setup(x => x.AddAsync(It.IsAny<BuildItem>())).Callback(
                (BuildItem buildItem) => listOfBuildItems.Add(buildItem));

            var itemService = new ItemsService(mockRepoBuildItems.Object, mockRepoItems.Object);
            AutoMapperConfig.RegisterMappings(typeof(MyTestItemGetByName).Assembly);

            var itemByName = itemService.GetByName<MyTestItemGetByName>("FirstItem");

            Assert.NotNull(itemByName);
        }

        [Fact]
        public async Task ItemsGetByIdMethodShouldWorkCorrect()
        {
            var listOfItems = new List<Item> { new Item { Id = "1", Name = "FirstItem", ImageUrl = "None" } };
            var listOfBuilds = new List<Build> { new Build { Id = "1", Name = "FirstBuild" } };
            var listOfBuildItems = new List<BuildItem> { new BuildItem { Id = "1", BuildId = "1", ItemId = "1" } };

            var mockRepoItems = new Mock<IDeletableEntityRepository<Item>>();
            mockRepoItems.Setup(x => x.AllAsNoTracking()).Returns(listOfItems.AsQueryable());
            mockRepoItems.Setup(x => x.AddAsync(It.IsAny<Item>())).Callback(
                (Item item) => listOfItems.Add(item));

            var mockRepoBuilds = new Mock<IDeletableEntityRepository<Build>>();
            mockRepoBuilds.Setup(x => x.AllAsNoTracking()).Returns(listOfBuilds.AsQueryable());
            mockRepoBuilds.Setup(x => x.AddAsync(It.IsAny<Build>())).Callback(
                (Build build) => listOfBuilds.Add(build));

            var mockRepoBuildItems = new Mock<IRepository<BuildItem>>();
            mockRepoBuildItems.Setup(x => x.AllAsNoTracking()).Returns(listOfBuildItems.AsQueryable());
            mockRepoBuildItems.Setup(x => x.AddAsync(It.IsAny<BuildItem>())).Callback(
                (BuildItem buildItem) => listOfBuildItems.Add(buildItem));

            var itemService = new ItemsService(mockRepoBuildItems.Object, mockRepoItems.Object);
            AutoMapperConfig.RegisterMappings(typeof(MyTestItemGetById).Assembly);

            var itemById = itemService.GetById<MyTestItemGetById>("1");

            Assert.NotNull(itemById);
        }
    }
}
