public interface IAbility
{
    public void Use();

    public bool CheckIfActive();

    public void ResetAbility();

    public void ActivateAbility();
}

public class Smash(Ball ball) : IAbility
{
    bool isActive = false;
    public void Use() {
        ball.directionX = 2;
    }

    public void ActivateAbility() {
        isActive = true;
    }

    public bool CheckIfActive() {
        return isActive;
    }

        public void ResetAbility() {
        isActive = false;
    }
    
}

public class Screw(Ball ball) : IAbility {
    bool isActive = false;
    public void Use() {
        ball.directionY = 2;
    }

        public void ActivateAbility() {
        isActive = true;
    }
    
        public bool CheckIfActive() {
        return isActive;
    }

    public void ResetAbility() {
        isActive = false;
    }
}