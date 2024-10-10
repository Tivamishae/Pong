using System;


namespace Boll {
    public class Boll {
    public int bollY;
    public int bollX;

    public int directionY = 1;
    public int directionX = 1;

    public Boll(int xValue, int yValue) {
        bollX = xValue;
        bollY = yValue;
    }

    public void move() {
        bollY += directionY;
        bollX += directionX;
    }

    public List<int> getBallCurrentPosition() {
        return [bollX, bollY];
    }
}
}