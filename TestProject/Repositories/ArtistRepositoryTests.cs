using ArtistSite.Repositories;
using DataLayer;
using Model;
using Moq;
using NUnit.Framework;
using System.Threading.Tasks;

namespace TestProject.Repositories
{
    [TestFixture]
    class ArtistRepositoryTests
    {
        [Test]
        public async Task UpdateAsync_WhenCalled_ShouldCallUpdateAsync()
        {
            // Arrange
            var repository = new Mock<IRepositoryAsync<Artist>>();
            repository.Setup(x => x.UpdateAsync(It.IsAny<Artist>())).Returns(Task.CompletedTask);

            var context = new Mock<ArtistContext>();
            var artistRepository = new ArtistRepository(repository.Object, context.Object);

            // Act
            await artistRepository.UpdateAsync(new Artist());

            // Assert
            repository.Verify(x => x.UpdateAsync(It.IsAny<Artist>()));
        }
    }
}
