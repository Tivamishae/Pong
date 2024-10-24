using System;


class Program
{
    static void Main()
    {
        Arena arenan = new Arena(20, 80);
        Ball ball1 = new Ball(40, 10);
        IAbility playerAbi = new Screw(ball1);
        IAbility playerAbi2 = new Smash(ball1);
        humanRacketBuilder racket1 = new humanRacketBuilder(1, 10, true, playerAbi);
        humanRacketBuilder racket2 = new humanRacketBuilder(78, 10, false, playerAbi2);


        Game game = new Game(ball1, racket1, racket2, arenan);
    }
}