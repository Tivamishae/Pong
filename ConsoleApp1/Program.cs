using System;


class Program
{
    static void Main()
    {
        

        Ball ball1 = new Ball(10, 10);
        humanRacketBuilder racket1 = new humanRacketBuilder(10, 1, true);
        humanRacketBuilder racket2 = new humanRacketBuilder(10, 78, false);
        Arena arenan = new Arena(20, 80);



        Game.createGame(ball1, racket1, racket2, arenan);
    }
}