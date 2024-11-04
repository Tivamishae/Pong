class UI(IPlayer player1, IPlayer player2)
{
    public void CreateUI()
    {
        Console.Write(player1.Name.PadRight(63));
        Console.Write(player2.Name);

        Console.WriteLine();
        Console.WriteLine();

        Console.Write(player1.Score.ToString().PadRight(63));
        Console.Write(player2.Score.ToString());

        Console.WriteLine();
        Console.WriteLine();

        if (player1.AbilityIsActive)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        Console.Write("-" + player1.AbilityIterator.Current.Name + "-");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write((" Cooldown: " + DisplayedAbilityCooldown(player1)).PadRight(56));

        if (player2.AbilityIsActive)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        Console.Write("-" + player2.AbilityIterator.Current.Name + "-");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" Cooldown: " + DisplayedAbilityCooldown(player2));

        Console.WriteLine();
        Console.WriteLine();



    }

    void IncrementScore(IPlayer player)
    {
        player.Score += 1;
    }

    string DisplayedAbilityCooldown(IPlayer player)
    {
        List<string> displayedCooldownList = new List<string>();
        for (int i = 0; i < player.Cooldown; i++)
        {
            displayedCooldownList.Add("#");
        }
        return string.Join("", displayedCooldownList);

    }
}