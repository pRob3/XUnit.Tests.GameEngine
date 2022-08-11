using Xunit;

namespace GameEngine.Tests;

public class EnemyFactoryShould
{
    [Fact]
    public void CreateNormalEnemyDefault()
    {
        EnemyFactory sut = new();
        
        Enemy enemy = sut.Create("Zombie");

        Assert.IsType<NormalEnemy>(enemy);
    }

    [Fact]
    public void CreateNormalEnemyByDefault_NotTypeExample()
    {
        EnemyFactory sut = new();

        Enemy enemy = sut.Create("Zombie");

        Assert.IsNotType<DateTime>(enemy);
    }

    [Fact]
    public void CreateBossEnemy(){
        EnemyFactory sut = new();

        Enemy enemy = sut.Create("Zombie King", true);
        
        Assert.IsNotType<NormalEnemy>(enemy);
        Assert.IsType<BossEnemy>(enemy);
    }

    [Fact]
    public void CreateBossEnemy_CastReturnedTypeExampe()
    {
        EnemyFactory sut = new();

        Enemy enemy = sut.Create("Zombie King", true);

        // Assert and get cast result
        BossEnemy boss = Assert.IsType<BossEnemy>(enemy);

        // Additional asserts on typed object
        Assert.Equal("Zombie King", boss.Name);
    }

    [Fact]
    public void CreateBossEnemy_AssertAssigableTypes()
    {
        EnemyFactory sut = new();

        Enemy enemy = sut.Create("Zombie King", true);

        //Assert.IsType<Enemy>(enemy);
        Assert.IsAssignableFrom<Enemy>(enemy);
    }
    
}
