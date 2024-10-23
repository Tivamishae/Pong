public interface IAbility
{
    public void Use();

    public bool CheckIfActive();

    public void ActivateAbility();

    public int CheckAbilityCooldown();

    public void ReduceAbilityCooldown();

    public string ReturnAbilityName();
}

public class Screw(Ball ball) : IAbility
{
    bool isActive = false;
    int abilityCooldown = 0;
    string abilityName = "Screw";
    public void Use() {
        ball.changeYDirection(2, false);
        isActive = false;
        abilityCooldown = 10;
    }

    public string ReturnAbilityName() {
        return abilityName;
    }

    public void ActivateAbility() {
        if (abilityCooldown == 0) {
            isActive = true;
        }
    }

    public bool CheckIfActive() {
        return isActive;
    }

    public int CheckAbilityCooldown() {
        return abilityCooldown;
    }

    public void ReduceAbilityCooldown() {
        abilityCooldown -= 1;
    }
    
}

public class Smash(Ball ball) : IAbility
{
    int abilityCooldown = 0;
    bool isActive = false;
    string abilityName = "Smash";
    public void Use() {
        ball.changeXDirection(-3);
        isActive = false;
        abilityCooldown = 10;
    }

    public void ActivateAbility() {
        if (abilityCooldown == 0) {
            isActive = true;
        }
    }

    public string ReturnAbilityName() {
        return abilityName;
    }

    public bool CheckIfActive() {
        return isActive;
    }

        public int CheckAbilityCooldown() {
        return abilityCooldown;
    }

    public void ReduceAbilityCooldown() {
        abilityCooldown -= 1;
    }
    
}