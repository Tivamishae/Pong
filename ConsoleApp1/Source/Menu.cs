
public class IMenu
{

    protected static void DrawMenu(string[] menu, int index)
    {
        Console.Clear();
        for (int i = 0; i < menu.Length; i++)
        {
            if (i == index) 
            {
                Console.WriteLine($"[{menu[i]}]");
            }
            else 
            {   
                Console.WriteLine($"{menu[i]}");
            }
        }
    }
    protected void Scroll(string[] menu, ref int index)
    {
        bool selecting = true;
    
        while(selecting)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            switch (keyInfo.Key)
            {
                case ConsoleKey.W:
                    index = PreviousIndex(menu, index);
                    break;
                case ConsoleKey.UpArrow:
                    index = PreviousIndex(menu, index);
                    break;
                case ConsoleKey.S:
                    index = NextIndex(menu, index);
                    break;
                case ConsoleKey.DownArrow:
                    index = NextIndex(menu, index);
                    break;
                case ConsoleKey.Enter:
                    selecting = false;
                    break;
 
            }

            DrawMenu(menu, index);

        }
    }
    protected int NextIndex(string[] menu, int index)
    {
        index++;

        if (index >= menu.Length)
        {
            index = 0;
        }
        return index;
    }

    protected int PreviousIndex(string[] menu, int index)
    {
        index--;
        if (index < 0)
        {
            index = menu.Length - 1; 
        }
        return index;
    }
}

public class StartingMenu : IMenu
{
    public int MenuReturnIndex()
    {
        Console.WriteLine("Welcome to Pong!");

        string[] startingMenu = {"Player vs. Player", "Player vs. Computer", "Computer vs. Computer"};   
        int index = 0;

        Console.WriteLine("What kind of game do you want to play?");
        DrawMenu(startingMenu, index);
        Scroll(startingMenu, ref index);

        Console.Clear(); 

        return index;
    }


}

public class EndMenu : IMenu
{
    
}