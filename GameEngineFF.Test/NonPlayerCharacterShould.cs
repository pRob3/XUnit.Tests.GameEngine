using Xunit;

namespace GameEngine.Tests;

public class NonPlayerCharacterShould
{

    [Theory]
    [MemberData(nameof(InternalHealthDamageTestData.TestData), MemberType = typeof(InternalHealthDamageTestData))]
    public void TakeDamage(int damage, int expectedHealth)
    {
        NonPlayerCharacter sut = new NonPlayerCharacter();

        sut.TakeDamage(damage);

        Assert.Equal(expectedHealth, sut.Health);
    }

    [Theory]
    [MemberData(
        nameof(ExternalHealthDamageTestData.TestData), 
        MemberType = typeof(ExternalHealthDamageTestData))]
    public void TakeDamageFromExternalTestData(int damage, int expectedHealth)
    {
        NonPlayerCharacter sut = new NonPlayerCharacter();

        sut.TakeDamage(damage);

        Assert.Equal(expectedHealth, sut.Health);
    }

    [Theory]
    [HealthDamageData]
    public void TakeDamageAttribute(int damage, int expectedHealth)
    {
        NonPlayerCharacter sut = new NonPlayerCharacter();

        sut.TakeDamage(damage);

        Assert.Equal(expectedHealth, sut.Health);
    }
}
