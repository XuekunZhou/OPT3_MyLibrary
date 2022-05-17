#nullable disable
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using MyLibrary.Controllers;
using MyLibrary.Models;
using Xunit;

namespace test
{
    public class TestHomeController
    {
        // Pairwise testing

        // A: T = 120
        // B: T = 850
        // C: T = 1320

        // X: Entry is younger than 7 days
        // Y: Entry is older than 7 days (so its t gets subtracted from T)

        // P: User is logged in
        // Q: User is not logged in

        private ApplicationDbContext context;
        private ApplicationUser alice;

        private void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestHomeController").Options;
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

        private Mock<UserManager<ApplicationUser>> GetMockUserManager(ApplicationUser loggedInUser)
        {
            var mgr = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);;
            mgr.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(loggedInUser);    

            return mgr;
        }

        [Fact]
        public async Task A_X_PAsync()
        {
            // Given
            Setup();
            var mgr = GetMockUserManager(alice);
            var sut = new HomeController(context, mgr.Object);
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 120, DateOfEntry = DateTime.Now, User = alice});
            context.SaveChanges();

            // When
            var res = await sut.IndexAsync();
            var viewRes = Assert.IsType<ViewResult>(res);

            // Then
            Assert.Equal("", viewRes.ViewData["Warning"]);
            Dispose();
        }

        [Fact]
        public async Task A_Y_QAsync()
        {
            // Given
            Setup();
            var mgr = GetMockUserManager(null);
            var sut = new HomeController(context, mgr.Object);
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 120, DateOfEntry = DateTime.Now.AddDays(-8), User = alice});
            context.SaveChanges();

            // When
            var res = await sut.IndexAsync();
            var viewRes = Assert.IsType<ViewResult>(res);

            // Then
            Assert.Equal("", viewRes.ViewData["Warning"]);
            Dispose();
        }

        [Fact]
        public async Task B_X_QAsync()
        {
            // Given
            Setup();
            var mgr = GetMockUserManager(null);
            var sut = new HomeController(context, mgr.Object);
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 850, DateOfEntry = DateTime.Now, User = alice});
            context.SaveChanges();

            // When
            var res = await sut.IndexAsync();
            var viewRes = Assert.IsType<ViewResult>(res);

            // Then
            Assert.Equal("", viewRes.ViewData["Warning"]);
            Dispose();
        }

        [Fact]
        public async Task B_Y_PAsync()
        {
            // Given
            Setup();
            var mgr = GetMockUserManager(alice);
            var sut = new HomeController(context, mgr.Object);
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 850, DateOfEntry = DateTime.Now.AddDays(-8), User = alice});
            context.SaveChanges();

            // When
            var res = await sut.IndexAsync();
            var viewRes = Assert.IsType<ViewResult>(res);

            // Then
            Assert.Equal("", viewRes.ViewData["Warning"]);
            Dispose();
        }

        [Fact]
        public async Task C_X_PAsync()
        {
            // Given
            Setup();
            var mgr = GetMockUserManager(alice);
            var sut = new HomeController(context, mgr.Object);
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 1320, DateOfEntry = DateTime.Now, User = alice});
            context.SaveChanges();

            // When
            var res = await sut.IndexAsync();
            var viewRes = Assert.IsType<ViewResult>(res);

            // Then
            Assert.Equal("You REALLY should spent less time on this", viewRes.ViewData["Warning"]);
            Dispose();
        }

        [Fact]
        public async Task C_Y_QAsync()
        {
            // Given
            Setup();
            var mgr = GetMockUserManager(null);
            var sut = new HomeController(context, mgr.Object);
            context.Add(new FilmEntryModel{Title = "a", LengthInMinutes = 1320, DateOfEntry = DateTime.Now.AddDays(-8), User = alice});
            context.SaveChanges();

            // When
            var res = await sut.IndexAsync();
            var viewRes = Assert.IsType<ViewResult>(res);

            // Then
            Assert.Equal("", viewRes.ViewData["Warning"]);
            Dispose();
        }
    }
}