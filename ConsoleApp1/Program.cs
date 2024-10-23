using System;


class Program
{
    static void Main()
    {
        Arena arenan = new Arena(20, 80);
        Ball ball1 = new Ball(40, 10);
        IAbility playerAbi = new Smash(ball1);
        IAbility playerAbi2 = new Smash(ball1);
        humanRacketBuilder racket1 = new humanRacketBuilder(1, 10, true, playerAbi);
        computerRacketBuilder racket2 = new computerRacketBuilder(78, 10, ball1, playerAbi2);


        Game.createGame(ball1, racket1, racket2, arenan);
    }
}