using Repository.DataModels;
using Repository.DataModels.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Repository.Tests
{
    public class RepositoryTests
    {
        private Repository<Entity> repository;

        private void ResetRepository()
        {
            repository = new Repository<Entity>(new List<Entity>
            {
                new Entity(1),
                new Entity(2),
                new Entity(3),
                new Entity(4),
                new Entity(5)
            });
        }

        [Fact]
        public void All_ShouldReturnEqualEntitiesCount()
        {
            // Arrange
            ResetRepository();

            // Actual
            var actual = repository.All();

            // Assert
            Assert.Equal(repository.Entities.Count(), actual.Count());
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void Delete_ValidId_ShouldRemoveSpecifiedEntity(int id)
        {
            // Arrange
            ResetRepository();
            int countBeforeDelete = repository.Entities.Count();

            // Actual
            repository.Delete(id);
            int countAfterDelete = repository.Entities.Count();

            // Assert
            Assert.True(countBeforeDelete > countAfterDelete);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(0)]
        [InlineData(-1)]
        public void Delete_InvalidId_ShouldRemoveNothing(int id)
        {
            // Arrange
            ResetRepository();
            int countBeforeDelete = repository.Entities.Count();

            // Actual
            repository.Delete(id);
            int countAfterDelete = repository.Entities.Count();

            // Assert
            Assert.Equal(countBeforeDelete, countAfterDelete);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void FindById_ValidId_ShouldReturnCorrectEntity(int id)
        {
            // Arrange
            ResetRepository();

            // Actual
            var actual = repository.FindById(id);

            // Assert
            Assert.Equal(repository.Entities.Where(x => x.Id.CompareTo(actual) == 0).FirstOrDefault(), actual);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(0)]
        [InlineData(-1)]
        public void FindById_InvalidId_ShouldReturnNull(int id)
        {
            // Arrange
            ResetRepository();

            // Actual
            var actual = repository.FindById(id);

            // Assert
            Assert.Null(actual);
        }

        [Theory]
        [InlineData(6)]
        [InlineData(100)]
        public void Save_ValidId_ShouldAddNewListItem(int id)
        {
            // Arrange
            ResetRepository();
            int beforeSavingEntity = repository.Entities.Count();

            // Actual
            repository.Save(new Vehicle(id));
            int afterSavingEntity = repository.Entities.Count();

            // Assert
            Assert.True(beforeSavingEntity < afterSavingEntity);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Save_InvalidId_ShouldReturnArgException(int id)
        {
            // Arrange
            ResetRepository();

            // Actual
            // Assert
            Assert.Throws<ArgumentException>(() => repository.Save(new Vehicle(id)));
        }
    }
}
