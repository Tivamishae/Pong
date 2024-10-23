public interface IAbility
{
    public void Use();

    public bool CheckIfActive();

    public void ActivateAbility();
}

public class Smash(Ball ball) : IAbility
{
    bool isActive = false;
    public void Use() {
        ball.changeYDirection(2, false);
        isActive = false;
    }

    public void ActivateAbility() {
        isActive = true;
    }

    public bool CheckIfActive() {
        return isActive;
    }
    
}