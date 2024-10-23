public interface IRacketBuilder 
{
    void RacketAction(Ball ball);

    int getXPosition();

    int getYPosition();

    void addPoint();

    int currentPoint();

    bool CheckIfAbilityActive();

    void UseAbility();
}

public class humanRacketBuilder : IRacketBuilder
{
    private int xPosition;
    private int yPosition;

    private int Points = 0;
    private bool isFirstPlayer;

    private IAbility ability;

    public humanRacketBuilder(int xPos, int yPos, bool isFirstPlayer, IAbility ability) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.isFirstPlayer = isFirstPlayer;
        this.ability = ability;
    }

    public void UseAbility() {
        ability.Use();
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
                        this.xPosition = xPosition - 1;
                        break;
                    case ConsoleKey.DownArrow:
                        this.xPosition = xPosition + 1;
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


    private IAbility ability;

    public computerRacketBuilder(int xPos, int yPos, Ball ball, IAbility ability) 
    {
        this.xPosition = xPos;
        this.yPosition = yPos;
        this.ability = ability;
    }

    public bool CheckIfAbilityActive() {
        return ability.CheckIfActive();
    }

     public void UseAbility() {
        ability.Use();
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