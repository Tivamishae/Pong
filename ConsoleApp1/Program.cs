using System;


class Program
{
    static void Main()
    {
        Arena arenan = new Arena(20, 80);
        Ball ball1 = new Ball(10, 40);
        IAbility playerAbi = new Smash(ball1);
        IAbility playerAbi2 = new Screw(ball1);
        humanRacketBuilder racket1 = new humanRacketBuilder(10, 1, true, playerAbi);
        humanRacketBuilder racket2 = new humanRacketBuilder(10, 78, false, playerAbi2);


        Game.createGame(ball1, racket1, racket2, arenan);
    }
}