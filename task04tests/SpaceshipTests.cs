namespace task04tests;

using Xunit;
using task04;

public class SpaceshipTests
{
    [Fact]
    public void Cruiser_ShouldHaveCorrectStats()
    {
        var cruiser = new Cruiser();
        Assert.Equal(50, cruiser.Speed);
        Assert.Equal(100, cruiser.FirePower);
    }

    [Fact]
    public void Fighter_ShouldBeFasterThanCruiser()
    {
        var fighter = new Fighter();
        var cruiser = new Cruiser();
        Assert.True(fighter.Speed > cruiser.Speed);
    }

    [Fact]
    public void Fighter_ShouldMoveCorrectly()
    {
        var fighter = new Fighter();
        fighter.Rotate(240);
        fighter.MoveForward();
        fighter.Rotate(180);
        Assert.Equal(60, fighter.CurrentAngle);
        Assert.Equal(1, fighter.Distance);
    }

    [Fact]
    public void Cruiser_ShouldMoveCorrectly()
    {
        var cruiser = new Cruiser();
        cruiser.Rotate(240);
        cruiser.MoveForward();
        cruiser.Rotate(180);
        Assert.Equal(60, cruiser.CurrentAngle);
        Assert.Equal(1, cruiser.Distance);
    }

    [Fact]
    public void Fighter_ShouldFireCorrectly()
    {
        var fighter = new Fighter();
        fighter.Fire();
        Assert.Equal(1, fighter.RocketsShot);
    }

    [Fact]
    public void Cruiser_ShouldFireCorrectly()
    {
        var cruiser = new Cruiser();
        cruiser.Fire();
        Assert.Equal(1, cruiser.RocketsShot);
    }
}