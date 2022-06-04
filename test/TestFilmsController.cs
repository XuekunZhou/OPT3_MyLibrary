#nullable disable
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyLibrary.Models;
using Moq;
using Xunit;
using MyLibrary.Controllers;
using System.Threading.Tasks;

namespace test;

public class TestFilmsController
{
    // A: list is public
    // B: UserOne is friends with UserTwo
    // C: UserOne is logged in

    private ApplicationDbContext context;
    private ApplicationUser alice;
    private ApplicationUser bob;
    private ApplicationUser carol;

    private void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestFilmController").Options;
        context = new ApplicationDbContext(options);
        context.Database.EnsureCreated();

        alice = new ApplicationUser();
        alice.Id = "111";

        bob = new ApplicationUser();
        bob.Id = "222";
        bob.listsArePublic = true;

        carol = new ApplicationUser();
        carol.Id = "333";

        var friend = new Friendship();
        friend.UserOne = alice;
        friend.UserTwo = bob;

        context.Add(alice);
        context.Add(bob);
        context.Add(carol);
        context.Add(friend);

        context.SaveChanges();
    }

    private void Dispose()
    {
        context.Database.EnsureDeleted();
    }

    private Mock<UserManager<ApplicationUser>> GetMockUserManager(ApplicationUser loggedInUser, ApplicationUser wachtedUser)
    {
        var mgr = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);;
        mgr.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(loggedInUser);    
        mgr.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(wachtedUser);

        return mgr;
    }

    [Fact]
    public async Task Test_NotA_NotB_C_Results_FalseAsync()
    {
        // Given
        Setup();
        var mgr = GetMockUserManager(alice, carol);
        var sut = new FilmsController(context, mgr.Object);

        // When
        var res = await sut.ListAsync(carol.Id);
        var viewResult = Assert.IsType<ViewResult>(res);

        // Then
        Assert.Equal("Private", viewResult.ViewName);
        Dispose();
    }

    [Fact]
    public async Task Test_NotA_B_C_Results_TrueAsync()
    {
        // Given
        Setup();
        var mgr = GetMockUserManager(alice, bob);
        var sut = new FilmsController(context, mgr.Object);

        // When
        var res = await sut.ListAsync(bob.Id);
        var viewResult = Assert.IsType<ViewResult>(res);

        // Then
        Assert.Equal("List", viewResult.ViewName);
        Dispose();
    }

    [Fact]
    public async Task Test_NotA_B_NotC_Results_FalseAsync()
    {
        // Given
        Setup();
        var mgr = GetMockUserManager(null, carol);
        var sut = new FilmsController(context, mgr.Object);

        // When
        var res = await sut.ListAsync(carol.Id);
        var viewResult = Assert.IsType<RedirectToActionResult>(res);

        // Then
        Assert.Equal("Login", viewResult.ActionName);
        Dispose();
    }

    [Fact]
    public async Task Test_A_NotB_C_Results_TrueAsync()
    {
        // Given
        Setup();
        var mgr = GetMockUserManager(carol, bob);
        var sut = new FilmsController(context, mgr.Object);

        // When
        var res = await sut.ListAsync(bob.Id);
        var viewResult = Assert.IsType<ViewResult>(res);

        // Then
        Assert.Equal("List", viewResult.ViewName);
        Dispose();
    }
}