using System;


namespace Racket {
    public class Racket {
    public int racketY;
    public int racketX;

    public int directionY = 3;
    public int directionX = 1;

    public Racket(int xValue, int yValue) {
        racketX = xValue;
        racketY = yValue;
    }

    public void move() {
        racketY += directionY;
        racketX += directionX;
    }

    public List<int> getRacketCurrentPosition() {
        return [racketX, racketY];
    }
}
}