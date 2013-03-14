using System.Collections.Generic;
using System.Linq;
using Moq;
using PodcastModel;
using Web.Podcasts.Controllers;
using PodcastsRepository;
using Xunit;

namespace Podcasts.Tests.Controllers
{
    public class ValuesControllerTest
    {
        [Fact]
        public void Get()
        {
            // Arrange
            var controller = new ValuesController(new Mock<IRepository<Feed>>().Object);

            // Act
            IEnumerable<Feed> result = controller.Get().ToArray();

            // Assert
            Assert.NotNull(result);  
            Assert.Equal(2, result.Count());
            Assert.Equal("value1", result.ElementAt(0).Name);
            Assert.Equal("value2", result.ElementAt(1).Name);
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            var controller = new ValuesController(new Mock<IRepository<Feed>>().Object);

            // Act
            string result = controller.Get(5);

            // Assert
            Assert.Equal("value", result);
        }

        [Fact]
        public void Post()
        {
            // Arrange
            var controller = new ValuesController(new Mock<IRepository<Feed>>().Object);

            // Act
            controller.Post("value");

            // Assert
        }

        [Fact]
        public void Put()
        {
            // Arrange
            var controller = new ValuesController(new Mock<IRepository<Feed>>().Object);

            // Act
            controller.Put(new Feed{Id = 5});

            // Assert
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var controller = new ValuesController(new Mock<IRepository<Feed>>().Object);

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
