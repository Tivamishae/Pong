public abstract class AbstractAbility
{

    public virtual string Name { get; set; } = "";

    public abstract void UseAbility();

}
// Strategy pattern
/* Vi nyttjar vår abstrakta klass AbstractAbility som vår abstrakta strategi, har därefter skapat våra konkreta strategier
screw och smash som blir injekterade i kontexten AbilityInventory.
*/
/* Vi använder det eftersom vi vill kunna iterera över supertypen AbstractAbility i vår iterator. Vi kan därmed skapa en iterable som innehåller
våra subtyper screw och smash fast de kompileras som AbstractAbility.
*/

public class Screw(Ball ball) : AbstractAbility
{
    public Ball Ball { get; set; } = ball;
    public override string Name { get; set; } = "Screw";
    public override void UseAbility()
    {
        Ball.YDirection = Math.Sign(Ball.YDirection) * 2;
    }
}

public class Smash(Ball ball) : AbstractAbility
{
    public Ball Ball { get; set; } = ball;

    public override string Name { get; set; } = "Smash";

    public override void UseAbility()
    {
        Ball.XDirection = Math.Sign(Ball.XDirection) * 2;
    }
}