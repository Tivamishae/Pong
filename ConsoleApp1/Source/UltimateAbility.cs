public interface UltimateAbility
{
    string Name { get; }

    bool UltimateAbilityActive { get; set; }

    void UseAbility();
    public int UltimateAbilityCooldown { get; set; }

    public Task ReduceUltimateAbilityCooldown();

    int Uses { get; set; }
}

public class ChangeDirection(Ball ball) : UltimateAbility
{
    public string Name { get; } = "Change Direction";

    Ball Ball = ball;

    public bool UltimateAbilityActive { get; set; } = false;

    public int UltimateAbilityCooldown { get; set; } = 0;

    public int Uses { get; set; } = 3;

    public void UseAbility()
    {
        if (Uses > 0 && UltimateAbilityCooldown == 0 && ball.Coordinates[0].Item1 > 20 && ball.Coordinates[0].Item1 < 50)
        {
            Uses -= 1;
            UltimateAbilityActive = true;
            Ball.XDirection = -Ball.XDirection;
            UltimateAbilityCooldown = 10;
            _ = ReduceUltimateAbilityCooldown();
        }
    }

    public async Task ReduceUltimateAbilityCooldown()
    {
        while (UltimateAbilityCooldown > 0)
        {
            UltimateAbilityCooldown -= 1;

            await Task.Delay(1000);
        }
    }
}

public class StopBall(Ball ball) : UltimateAbility
{
    public string Name { get; } = "StopBall";
    Ball ball = ball;
    public int Uses { get; set; } = 3;
    int savedBallDirectionX;
    int savedBallDirectionY;
    public int UltimateAbilityCooldown { get; set; } = 0;

    public bool UltimateAbilityActive { get; set; } = false;

    public void UseAbility()
    {
        if (Uses > 0 && UltimateAbilityCooldown == 0)
        {
            Uses -= 1;
            UltimateAbilityActive = true;
            savedBallDirectionX = ball.XDirection;
            savedBallDirectionY = ball.YDirection;
            UltimateAbilityCooldown = 10;
            _ = ReduceUltimateAbilityCooldown();
            AbilityFunction();
            EndUltimateAbility();
        }
    }

    public void AbilityFunction()
    {
        ball.XDirection = 0;
        ball.YDirection = 0;
    }

    public async void EndUltimateAbility()
    {
        await Task.Delay(3000);
        ball.XDirection = savedBallDirectionX;
        ball.YDirection = savedBallDirectionY;
        UltimateAbilityActive = false;
    }


    public async Task ReduceUltimateAbilityCooldown()
    {
        while (UltimateAbilityCooldown > 0)
        {
            UltimateAbilityCooldown -= 1;

            await Task.Delay(1000);
        }
    }
}