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
        Console.Write("-" + player1.Ability.Name + "-");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write((" Cooldown: " + DisplayedCooldown(player1, player1.Cooldown)).PadRight(56));

        if (player2.AbilityIsActive)
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }
        Console.Write("-" + player2.Ability.Name + "-");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" Cooldown: " + DisplayedCooldown(player2, player2.Cooldown));

        Console.WriteLine();
        Console.WriteLine();

        Console.Write("-" + player1.Ability.UltimateAbility.Name + "-");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write((" Cooldown: " + DisplayedCooldown(player1, player1.Ability.UltimateAbility.UltimateAbilityCooldown)).PadRight(53));

        Console.Write("-" + player2.Ability.UltimateAbility.Name + "-");
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write(" Cooldown: " + DisplayedCooldown(player2, player2.Ability.UltimateAbility.UltimateAbilityCooldown));
        Console.WriteLine();

        Console.Write((" Uses: " + player1.Ability.UltimateAbility.Uses).PadRight(62));
        Console.Write(" Uses: " + player2.Ability.UltimateAbility.Uses);

        Console.WriteLine();
        Console.WriteLine();
    }

    void IncrementScore(IPlayer player)
    {
        player.Score += 1;
    }

    string DisplayedCooldown(IPlayer player, int cooldown)
    {
        List<string> displayedCooldownList = new List<string>();
        for (int i = 0; i < cooldown; i++)
        {
            displayedCooldownList.Add("#");
        }
        return string.Join("", displayedCooldownList);

    }
}