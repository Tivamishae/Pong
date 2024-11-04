

class Game(Ball ball, IPlayer player1, IPlayer player2, IMovement player1Movement, IMovement player2Movement, int amountOfRounds)
{
    public int Width = 80;
    public int Height = 20;
    public int AmountOfRounds = amountOfRounds;
    Ball Ball = ball;
    IPlayer Player1 = player1;
    IPlayer Player2 = player2;
    IMovement Player1Movement = player1Movement;
    IMovement Player2Movement = player2Movement;

    public (IPlayer, IPlayer) ReturnPlayers()
    {
        return (Player1, Player2);
    }

    public (IMovement Player1Movement, IMovement Player2Movement) ReturnMovement()
    {
        return (Player1Movement, Player2Movement);
    }

    public Ball ReturnBall()
    {
        return Ball;
    }

    public (int, int) ReturnArenaSize()
    {
        return (Width, Height);
    }
}