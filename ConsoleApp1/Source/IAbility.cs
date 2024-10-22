public interface IAbility
{
    void Use();

    bool CheckIfActive();
}

public class Smash(Ball ball) : IAbility
{
    bool isActive;
    public void Use() {
        ball.directionX = 2;
    }

    public bool CheckIfActive() {
        return isActive;
    }
    
}

public class SwitchDirection(Ball ball) : IAbility {
        bool isActive;
    public void Use() {
        ball.directionY = ball.directionY * -1;
    }
        public bool CheckIfActive() {
        return isActive;
    }
}

public class Screw(Ball ball) : IAbility {
        bool isActive;
    public void Use() {
        ball.directionY = 2;
    }
        public bool CheckIfActive() {
        return isActive;
    }
}