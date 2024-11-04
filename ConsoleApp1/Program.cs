

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Arena arena = CreateInstance();


        arena.GameLoop();
    }
    public static Arena CreateInstance()
    {

        Menu menu = new Menu();

        PlayerMovement player1Movement = new PlayerMovement(menu.Player1.RacketAction, ConsoleKey.W, ConsoleKey.S, ConsoleKey.F, ConsoleKey.D, menu.Ball);
        ArenaBorder arenaBorder = new ArenaBorder([], menu.BorderColor);

        Game game = new Game(menu.Ball, menu.Player1, menu.Player2, player1Movement, menu.Player2Movement, menu.AmountOfRounds);
        Arena arena = new Arena(game, arenaBorder, menu);

        return arena;

    }
}
