public interface IIterator<T>
{
    T Current { get; }
    bool MoveNext(int direction);
    void Reset();
}
//Generic interface, Iterator Pattern
/* Vi har valt att skapa två interface IIterator och IIterable som agerar som IIterator. Detta möjliggör att skapa iterators för olika
typer så som (IColor, string), (IBallShape, string), (IPlayer, string) med mera. 
*/

/* Vi har valt att göra detta eftersom vi på så sätt kan nyttja samma IIterator interface i olika tillfällen på olika typer. Vi hade
annars behövt skapa nya IITerator interface och IIterable interface för varje typ som vi vill iterera. Vi har också valt att skapa
en iterator pattern för att möjliggöra iterationen av såväl våra abilities som våra svarsalternativ i menyerna.
*/

public interface IIterable<T>
{
    public IIterator<T> CreateIterator();
}