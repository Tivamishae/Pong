using System;


class Program
{
    static void Main()
    {
        

        Ball ball1 = new Ball(15, 15);
        humanRacketBuilder racket1 = new humanRacketBuilder(10, 1, true);
        computerRacketBuilder racket2 = new computerRacketBuilder(10, 78, ball1);
        Arena arenan = new Arena(20, 80);



        Game.createGame(ball1, racket1, racket2, arenan);
    }
}