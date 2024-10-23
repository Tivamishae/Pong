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
        if (isFirstPlayer) {
            this.name = "Player 1";
        }
        else {
            this.name = "Player 2";
        }
    }

        public void HandleCooldownReduction() {
        if (ability.CheckAbilityCooldown() > 0) {
            abilityTickCounter += 1;
        }
        else {
            abilityTickCounter = 0;
        }
        if (abilityTickCounter == 10 && ability.CheckAbilityCooldown() > 0) {
            ability.ReduceAbilityCooldown();
            abilityTickCounter = 0;
        }
    }

    public void resetRacket() {
        yPosition = 10;
    }

    public string ReturnAbilityName() {
        return ability.ReturnAbilityName();
    }

    public string ReturnName() {
        return name;
    }

    public void UseAbility() {
        ability.Use();
    }

    public int CheckAbilityCooldown() {
        return ability.CheckAbilityCooldown();
    }

    public bool CheckIfAbilityActive() {
        return ability.CheckIfActive();
    }

    public void addPoint(){
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

                if (isFirstPlayer) {
                    switch (keyInfo.Key) {
                    case ConsoleKey.W:
                        this.yPosition = yPosition - 1;
                        break;
                    case ConsoleKey.S:
                        this.yPosition = yPosition + 1;
                        break;
                    case ConsoleKey.F:
                        ability.ActivateAbility();
                        break;

                    }
                }
                else {
                    switch (keyInfo.Key) {
                    case ConsoleKey.UpArrow:
                        this.yPosition = yPosition - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        this.yPosition = yPosition + 1;
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

    public computerRacketBuilder(int xPos, int yPos, bool isFirstPlayer, Ball ball, IAbility ability) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.ability = ability;

        if (isFirstPlayer) {
            name = "Player 1";
        }
        else {
            name = "Player 2";
        }
    }
    public void HandleCooldownReduction() {
        if (ability.CheckAbilityCooldown() > 0) {
            abilityTickCounter += 1;
        }
        else {
            abilityTickCounter = 0;
        }
        if (abilityTickCounter == 10 && ability.CheckAbilityCooldown() > 0) {
            ability.ReduceAbilityCooldown();
            abilityTickCounter = 0;
        }
    }

    public void resetRacket() {
        yPosition = 10;
    }

    public string ReturnAbilityName() {
        return ability.ReturnAbilityName();
    }

        public string ReturnName() {
        return name;
    }

    public bool CheckIfAbilityActive() {
        return ability.CheckIfActive();
    }

     public void UseAbility() {
        ability.Use();
    }

    public int CheckAbilityCooldown() {
        return ability.CheckAbilityCooldown();
    }

    

    public void addPoint(){
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
            if (yPosition < ball.getBallYPosition()) {
                this.yPosition = yPosition + 1;
            }
            else if (yPosition > ball.getBallYPosition()) {
                this.yPosition = yPosition - 1;
            }
        }

}