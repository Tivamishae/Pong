using System;


class Program
{
    static void Main()
    {
        

        Ball ball1 = new Ball(10, 10);
        humanRacketBuilder racket1 = new humanRacketBuilder(10, 1, 3);
        humanRacketBuilder racket2 = new humanRacketBuilder(10, 78, 3);

        Game.createArena(ball1, racket1, racket2);
    }
}