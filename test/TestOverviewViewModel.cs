#nullable disable
using System;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;
using Xunit;

namespace test
{
    public class TestOverviewViewModel
    {
        // Equivalance testing

        private ApplicationDbContext context;
        private ApplicationUser alice;

        private void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestOverviewViewModel").Options;
            context = new ApplicationDbContext(options);
            context.Database.EnsureCreated();

            alice = new ApplicationUser();

            context.Add(alice);

            context.SaveChanges();
        }

        private void Dispose()
        {
            context.Database.EnsureDeleted();
        }

        [Fact]
        public void EquivalenceClassOneLowerEdge()
        {
            // Given
           Setup();

            // When
            var sut = new OverviewViewModel(context, alice, 7);

            // Then
            Assert.Equal(0, sut.TimeSpentOnFilmsInMinutes);
            Dispose();
        }

        [Fact]
        public void EquivalenceClassOneUpperEdge()
        {
            // Given
            Setup();
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 100, DateOfEntry = DateTime.Now, User = alice});
            context.Add(new FilmEntryModel{Title = "b", LengthInMinutes = 100, DateOfEntry = DateTime.Now, User = alice});
            context.Add(new FilmEntryModel{Title = "c", LengthInMinutes = 639, DateOfEntry = DateTime.Now, User = alice});
            context.SaveChanges();
            
            // When
            var sut = new OverviewViewModel(context, alice, 7);

            // Then
            Assert.Equal(839, sut.TimeSpentOnFilmsInMinutes);
            Dispose();
        }

        [Fact]
        public void EquivalenceClassTwoLowerEdge()
        {
            // Given
            Setup();
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 100, DateOfEntry = DateTime.Now, User = alice});
            context.Add(new FilmEntryModel{Title = "b", LengthInMinutes = 200, DateOfEntry = DateTime.Now, User = alice});
            context.Add(new FilmEntryModel{Title = "c", LengthInMinutes = 540, DateOfEntry = DateTime.Now, User = alice});
            context.SaveChanges();
            
            // When
            var sut = new OverviewViewModel(context, alice, 7);

            // Then
            Assert.Equal(840, sut.TimeSpentOnFilmsInMinutes);
            Dispose();
        }

        [Fact]
        public void EquivalenceClassTwoUpperEdge()
        {
            // Given
            Setup();
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 100, DateOfEntry = DateTime.Now, User = alice});
            context.Add(new FilmEntryModel{Title = "b", LengthInMinutes = 100, DateOfEntry = DateTime.Now, User = alice});
            context.Add(new FilmEntryModel{Title = "c", LengthInMinutes = 659, DateOfEntry = DateTime.Now, User = alice});
            context.Add(new FilmEntryModel{Title = "d", LengthInMinutes = 400, DateOfEntry = DateTime.Now, User = alice});
            context.SaveChanges();
            
            // When
            var sut = new OverviewViewModel(context, alice, 7);

            // Then
            Assert.Equal(1259, sut.TimeSpentOnFilmsInMinutes);
            Dispose();
        }

        [Fact]
        public void EquivalenceClassThreeLowerEdge()
        {
            // Given
            Setup();
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 100, DateOfEntry = DateTime.Now, User = alice});
            context.Add(new FilmEntryModel{Title = "b", LengthInMinutes = 100, DateOfEntry = DateTime.Now, User = alice});
            context.Add(new FilmEntryModel{Title = "c", LengthInMinutes = 660, DateOfEntry = DateTime.Now, User = alice});
            context.Add(new FilmEntryModel{Title = "d", LengthInMinutes = 400, DateOfEntry = DateTime.Now, User = alice});
            context.SaveChanges();
            
            // When
            var sut = new OverviewViewModel(context, alice, 7);

            // Then
            Assert.Equal(1260, sut.TimeSpentOnFilmsInMinutes);
            Dispose();
        }

        [Fact]
        public void EquivalenceClassThree()
        {
            // Given
            Setup();
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 1000000, DateOfEntry = DateTime.Now, User = alice});
            
            context.SaveChanges();
            
            // When
            var sut = new OverviewViewModel(context, alice, 7);

            // Then
            Assert.Equal(1000000, sut.TimeSpentOnFilmsInMinutes);
            Dispose();
        }
    }
}