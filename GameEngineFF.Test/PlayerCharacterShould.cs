using System;
using Xunit;
using Xunit.Abstractions;

namespace GameEngine.Tests;

public class PlayerCharacterShould : IDisposable
{
    private readonly PlayerCharacter _sut;
    private readonly ITestOutputHelper _output;

    public PlayerCharacterShould(ITestOutputHelper output)
    {
        _sut = new PlayerCharacter();
        _output = output;

        _output.WriteLine("Creating new player character");
    }

    public void Dispose()
    {
        _output.WriteLine($"Disposing {_sut.FullName}");

        //_sut.Dispose();
    }


    [Fact]
    public void BeInexperiencedWhenNew()
    {
        Assert.True(_sut.IsNoob);
    }

    [Fact]
    public void CalculateFullName()
    {
        _sut.FirstName = "John";
        _sut.LastName = "Smith";

        Assert.Equal("John Smith", _sut.FullName);
    }

    [Fact]
    public void HaveFullNameStartingWithFirstName()
    {

        _sut.FirstName = "John";
        _sut.LastName = "Smith";

        Assert.StartsWith("John", _sut.FullName);
    }

    [Fact]
    public void HaveFullNameEndingWithLastName()
    {

        _sut.FirstName = "John";
        _sut.LastName = "Smith";


        Assert.EndsWith("Smith", _sut.FullName);
    }

    [Fact]
    public void CalculateFullName_IgnoreCaseAssertExample()
    {
        _sut.FirstName = "JOHN";
        _sut.LastName = "SMITH";

        Assert.EndsWith("Smith", _sut.FullName, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void CalculateFullName_SubstringAssertExample()
    {
        _sut.FirstName = "John";
        _sut.LastName = "Smith";

        Assert.Contains("hn Sm", _sut.FullName);
    }

    [Fact]
    public void CalculateFullNameWithTitleCase()
    {
        _sut.FirstName = "John";
        _sut.LastName = "Smith";

        Assert.Matches("[A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+", _sut.FullName);
    }

    [Fact]
    public void StartWithDefaultHealth()
    {

        Assert.Equal(100, _sut.Health);
    }

    [Fact]
    public void StartWithDefaulthealth_NotEqualExample()
    {
        Assert.NotEqual(0, _sut.Health);
    }

    [Fact]
    public void IncreaseHealthAfterSleeping()
    {
        _sut.Sleep(); // Expect to increase between 1 to 100 inclusive

        //Assert.True(sut.Health >= 101 && sut.Health <= 200);
        Assert.InRange(_sut.Health, 101, 200);
    }

    [Fact]
    public void NotHaveNicknameByDefault()
    {
        //Assert.NotNull(sut.Nickname);
        Assert.Null(_sut.Nickname);
    }

    [Fact]
    public void HaveALongBow()
    {
        Assert.Contains("Long Bow", _sut.Weapons);
    }

    [Fact]
    public void NotHaveAStaffOfWonder()
    {
        Assert.DoesNotContain("Staff Of Wonder", _sut.Weapons);
    }

    [Fact]
    public void HaveAtleastOneKindOfSword()
    {
        Assert.Contains(_sut.Weapons, w => w.Contains("Sword"));
    }

    [Fact]
    public void HaveAllExpectedWeapons()
    {
        Assert.Equal(
            new[] { "Long Bow", "Short Bow", "Short Sword" },
            _sut.Weapons);
    }

    [Fact]
    public void HaveNoEmptyDefaultWeapons()
    {
        Assert.All(_sut.Weapons, w => Assert.False(string.IsNullOrWhiteSpace(w)));
    }

    [Fact]
    public void RaiseSleptEvent()
    {
        Assert.Raises<EventArgs>(
            handler => _sut.PlayerSlept += handler,
            handler => _sut.PlayerSlept -= handler,
            () => _sut.Sleep());
    }

    [Fact]
    public void RaisePropertyChangedEvent()
    {
        Assert.PropertyChanged(_sut, "Health", () => _sut.TakeDamage(10));
    }
    
    [Theory]
    [MemberData(nameof(ExternalHealthDamageTestData.TestData), MemberType = typeof(ExternalHealthDamageTestData))]
    public void TakeDamage(int damage, int expectedHealth)
    {
        _sut.TakeDamage(damage);

        Assert.Equal(expectedHealth, _sut.Health);
    }

}
