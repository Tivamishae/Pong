using System.Runtime.CompilerServices;


//Bridge pattern
/* Vi har valt att skapa en interface AbstractAbility som injekterar ett objekt av typen UltimateAilitiebility. UltimateAbility är en interface som implementeras av andra konkreta klasser
som är våra ultimate abilities. Vårt interface AbstractAbility implementeras av flera olika abilities. Vi har alltså en bro mellan AbstractAbility och UltimateAbility som
möjliggör att vi kan mixa bland dessa två hursomhelst innan vi injekterar den i vår IPlayer.
*/
/* Vi har valt att göra detta eftersom vi lätt kan skapa nya abilities och ultimate abilities utan att behöva hårdkoda alla olika kombinationer.
*/
public interface AbstractAbility
{
    UltimateAbility UltimateAbility { get; set; }
    string Name { get; set; }

    public void UseAbility();

    public void UseUltimateAbility();
}

public class Screw(Ball ball, UltimateAbility ultimateAbility) : AbstractAbility
{
    public Ball Ball { get; set; } = ball;
    public UltimateAbility UltimateAbility { get; set; } = ultimateAbility;
    public string Name { get; set; } = "Screw";
    public void UseAbility()
    {
        Ball.YDirection = Math.Sign(Ball.YDirection) * 2;
    }

    public void UseUltimateAbility()
    {
        UltimateAbility.UseAbility();
    }
}


public class Smash(Ball ball, UltimateAbility ultimateAbility) : AbstractAbility
{
    public Ball Ball { get; set; } = ball;
    public UltimateAbility UltimateAbility { get; set; } = ultimateAbility;

    public string Name { get; set; } = "Smash";

    public void UseAbility()
    {
        Ball.XDirection = Math.Sign(Ball.XDirection) * 2;
    }

    public void UseUltimateAbility()
    {
        UltimateAbility.UseAbility();
    }
}