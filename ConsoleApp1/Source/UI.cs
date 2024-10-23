using System.Threading;
public class UI
{

    public static void Names(IRacketBuilder racket1, IRacketBuilder racket2)
    {

        Console.Write(racket1.ReturnName());

        for (int i = 0; i < 64; i++)
        {
            Console.Write(" ");
        }
        Console.Write(racket2.ReturnName());
        Console.WriteLine();
        Console.WriteLine();
    }

    public static void Scoreboard(IRacketBuilder racket1, IRacketBuilder racket2)
    {

        Console.Write("Score: " + racket1.currentPoint());

        for (int i = 0; i < 64; i++)
        {
            Console.Write(" ");
        }
        Console.Write("Score: " + racket2.currentPoint());
        Console.WriteLine();
        Console.WriteLine();
    }

    public static void AbilityRecharge(IRacketBuilder racket1, IRacketBuilder racket2)
    {
        Console.Write(racket1.ReturnAbilityName() + " cooldown " + racket1.CheckAbilityCooldown());
        for (int i = 0; i < 51; i++)
        {
            Console.Write(" ");
        }
        Console.Write(racket2.ReturnAbilityName() + " cooldown " + racket2.CheckAbilityCooldown());
        Console.WriteLine();
    }

}