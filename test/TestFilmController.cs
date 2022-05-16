using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;
using Xunit;

namespace test;

public class TestFilmController
{
    // A: list is public
    // B: UserOne is friends with UserTwo
    // C: UserOne is logged in

    private ApplicationDbContext? context;
    private ApplicationUser? alice;
    private ApplicationUser? bob;
    private ApplicationUser? carol;

    private void Setup()
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("TestAanmelding").Options;
        context = new ApplicationDbContext(options);
        context.Database.EnsureCreated();

        alice = new ApplicationUser();
        alice.Id = "111";

        bob = new ApplicationUser();
        bob.Id = "222";
        bob.listsArePublic = true;

        carol = new ApplicationUser();
        carol.Id = "333";

        var friend = new Friend();
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

    private Mock<UserManager<ApplicationUser>> GetMockUserManager(ApplicationUser loggedInUser)
    {
        var mgr = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);;
        mgr.Setup(x => x.GetUserAsync(It.IsAny<ClaimsPrincipal>())).ReturnsAsync(loggedInUser);    

        return mgr;
    }

    [Fact]
    public async void Test_NotA_NotB_C_Results_False()
    {
        // Given
        Setup();
        var mgr = GetMockUserManager(alice);
        var sut = new FilmController(context, mgr.Object);
    
        // When
        var res = await sut.Index(carol.Id);
        var viewResult = Assert.IsType<ViewResult>(res);

        // Then
        Assert.Equal("Private", viewResult.ViewName);
        Dispose();
    }

    [Fact]
    public void Test_NotA_B_C_Results_True()
    {
        // Given
        Setup();
        var mgr = GetMockUserManager(alice);
        var sut = new FilmController(context, mgr.Object);
    
        // When
        var res = await sut.Index(bob.Id);
        var viewResult = Assert.IsType<ViewResult>(res);

        // Then
        Assert.Equal("Index", viewResult.ViewName);
        Dispose();
    }

    [Fact]
    public void Test_NotA_B_NotC_Results_False()
    {
        // Given
        Setup();
        var sut = new FilmController(context);
    
        // When
        var res = await sut.Index(carol.Id);
        var viewResult = Assert.IsType<RedirectToActionResult>(res);

        // Then
        Assert.Equal("Login", viewResult.ActionName);
        Dispose();
    }

    [Fact]
    public void Test_A_NotB_C_Results_True()
    {
        // Given
        Setup();
        var mgr = GetMockUserManager(carol);
        var sut = new FilmController(context, mgr.Object);
    
        // When
        var res = await sut.Index(bob.Id);
        var viewResult = Assert.IsType<ViewResult>(res);

        // Then
        Assert.Equal("Index", viewResult.ViewName);
        Dispose();
    }
}