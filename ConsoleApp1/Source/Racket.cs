using System.Security.Cryptography.X509Certificates;
using System.Threading;
public interface IRacketBuilder

{
    void RacketAction(Ball ball);

    int getXPosition();

    int getYPosition();

    void addPoint();

    int currentPoint();

    bool CheckIfAbilityActive();

    void UseAbility();

    int CheckAbilityCooldown();

    string ReturnName();

    string ReturnAbilityName();

    void HandleCooldownReduction();

    void resetRacket();

}

public class humanRacketBuilder : IRacketBuilder
{
    private int xPosition;
    private int yPosition;

    private int Points = 0;
    private bool isFirstPlayer;

    private string name;
    private int abilityTickCounter;

    private IAbility ability;

    public humanRacketBuilder(int xPos, int yPos, bool isFirstPlayer, IAbility ability)
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.isFirstPlayer = isFirstPlayer;
        this.ability = ability;
        if (isFirstPlayer)
        {
            this.name = "Player 1";
        }
        else
        {
            this.name = "Player 2";
        }
    }

    public void HandleCooldownReduction()
    {
        if (ability.CheckAbilityCooldown() > 0)
        {
            abilityTickCounter += 1;
        }
        else
        {
            abilityTickCounter = 0;
        }
        if (abilityTickCounter == 10 && ability.CheckAbilityCooldown() > 0)
        {
            ability.ReduceAbilityCooldown();
            abilityTickCounter = 0;
        }
    }

    public void resetRacket()
    {
        yPosition = 10;
    }

    public string ReturnAbilityName()
    {
        return ability.ReturnAbilityName();
    }

    public string ReturnName()
    {
        return name;
    }

    public void UseAbility()
    {
        ability.Use();
    }

    public int CheckAbilityCooldown()
    {
        return ability.CheckAbilityCooldown();
    }

    public bool CheckIfAbilityActive()
    {
        return ability.CheckIfActive();
    }

    public void addPoint()
    {
        this.Points++;
    }

    public int currentPoint()
    {
        return Points;
    }

    public int getXPosition()
    {
        return xPosition;
    }

    public int getYPosition()
    {
        return yPosition;
    }

    public void RacketAction(Ball ball = null)
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

            if (isFirstPlayer)
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.W:
                        if (ball.directionX == 0)
                        {
                            ball.directionX = 1;
                            ball.directionY = -1;
                            ball.xBounces += 1;
                        }
                        else
                        {
                            this.yPosition = yPosition - 1;
                        }
                        break;
                    case ConsoleKey.S:
                        if (ball.directionX == 0)
                        {
                            ball.directionX = 1;
                            ball.directionY = 1;
                            ball.xBounces += 1;
                        }
                        else
                        {
                            this.yPosition = yPosition + 1;
                        }
                        break;
                    case ConsoleKey.F:
                        ability.ActivateAbility();
                        break;

                }
            }
            else
            {
                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (ball.directionX == 0)
                        {
                            ball.directionX = -1;
                            ball.directionY = -1;
                            ball.xBounces += 1;
                        }
                        else
                        {
                            this.yPosition = yPosition - 1;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (ball.directionX == 0)
                        {
                            ball.directionX = -1;
                            ball.directionY = 1;
                            ball.xBounces += 1;
                        }
                        else
                        {
                            this.yPosition = yPosition + 1;
                        }
                        break;
                    case ConsoleKey.L:
                        ability.ActivateAbility();
                        break;
                }
            }
        }
    }

}

public class computerRacketBuilder : IRacketBuilder
{
    private int xPosition;
    private int yPosition;

    private int Points = 0;

    private string name;

    private int abilityTickCounter = 0;


    private IAbility ability;
    public IMoveRacket movement;

    public computerRacketBuilder(int xPos, int yPos, bool isFirstPlayer, Ball ball, IAbility ability, IMoveRacket movement)
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.ability = ability;
        this.movement = movement;

        if (isFirstPlayer)
        {
            name = "Player 1";
        }
        else
        {
            name = "Player 2";
        }
    }
    public void HandleCooldownReduction()
    {
        if (ability.CheckAbilityCooldown() > 0)
        {
            abilityTickCounter += 1;
        }
        else
        {
            abilityTickCounter = 0;
        }
        if (abilityTickCounter == 10 && ability.CheckAbilityCooldown() > 0)
        {
            ability.ReduceAbilityCooldown();
            abilityTickCounter = 0;
        }
    }

    public void resetRacket()
    {
        yPosition = 10;
    }

    public string ReturnAbilityName()
    {
        return ability.ReturnAbilityName();
    }

    public string ReturnName()
    {
        return name;
    }

    public bool CheckIfAbilityActive()
    {
        return ability.CheckIfActive();
    }

    public void UseAbility()
    {
        ability.Use();
    }

    public int CheckAbilityCooldown()
    {
        return ability.CheckAbilityCooldown();
    }



    public void addPoint()
    {
        this.Points++;
    }

    public int currentPoint()
    {
        return Points;
    }

    public int getXPosition()
    {
        return xPosition;
    }

    public int getYPosition()
    {
        return yPosition;
    }

    public void RacketAction(Ball ball)
    {
        yPosition = movement.move(yPosition, ball);
    }

}