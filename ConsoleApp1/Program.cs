using System;
using System.Threading;
using Arena;

class Program
{
    static void Main()
    {
        Arena.Arena myArena = new Arena.Arena();

        while (myArena.game == true)
        {
            // Clear the previous output and reset the cursor position to the top left of the console
            Console.Clear();
            Console.SetCursorPosition(0, 0);

            // Check if a key is available
            if (Console.KeyAvailable)
            {
                // Read the key without blocking
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                // Handle the key press
                switch (keyInfo.Key)
                {
                                        case ConsoleKey.W:
                        myArena.updateRacket1(-1);
                        break;
                    case ConsoleKey.S:
                        myArena.updateRacket1(1);
                        break;
                    case ConsoleKey.UpArrow:
                        myArena.updateRacket2(-1);
                        break;
                    case ConsoleKey.DownArrow:
                        myArena.updateRacket2(1);
                        break;
                    default:
                        Console.WriteLine($"Key pressed: {keyInfo.KeyChar}");
                        break;
                }
            }

            // Update and draw the arena
            myArena.createArena();
            myArena.updateBoll();

            // Wait a short time before refreshing to make the changes visible
            Thread.Sleep(100);
        }
    }
}