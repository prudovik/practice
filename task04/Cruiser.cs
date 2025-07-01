namespace task04;

public class Cruiser : ISpaceship
{
    int speed = 50;
    int firepower = 100;
    public int CurrentAngle = 0;
    public int Distance = 0;
    public int RocketsShot = 0;
    public void MoveForward()
    {
        Distance++;
    }
    public void Rotate(int angle)
    {
        CurrentAngle += angle;
        if(CurrentAngle >= 360) CurrentAngle -= 360;
    }
    public void Fire() {
        RocketsShot++;
    }
    public int Speed => speed;
    public int FirePower => firepower;
}
