﻿using Xunit;

namespace GameEngine.Tests;

[Trait("Category", "Enemy")]
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

    [Fact]
    public void CreateSeparateInstances()
    {
        EnemyFactory sut = new();

        Enemy enemy1 = sut.Create("Zombie");
        Enemy enemy2 = sut.Create("Zombie");

        Assert.NotSame(enemy1, enemy2);
    }

    [Fact]
    public void NotAllowNullName()
    {
        EnemyFactory sut = new();
        
        //Assert.Throws<ArgumentNullException>(() => sut.Create(null));
        Assert.Throws<ArgumentNullException>("name", () => sut.Create(null));
    }

    [Fact]
    public void OnlyAllowKingOrQueenBoosEnemies()
    {
        EnemyFactory sut = new();

        EnemyCreationException ex = Assert.Throws<EnemyCreationException>(() => sut.Create("Zombie", true));

        Assert.Equal("Zombie", ex.RequestedEnemyName);
    }
}
