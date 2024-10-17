using System;
using Arena;


class Program
{
    static void Main()
    {
        Arena.Arena myArena = new Arena.Arena();

        Ball ball1 = new Ball(10, 10);
        humanRacketBuilder racket1 = new humanRacketBuilder(10, 1, 3);
        humanRacketBuilder racket2 = new humanRacketBuilder(10, 79, 3);

        myArena.createArena(ball1, racket1, racket2);
    }
}