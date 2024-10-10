using System;


namespace Boll {
    public class Boll {
    public int bollY;
    public int bollX;

    public int directionY;
    public int directionX;

    public void move() {
        bollY += directionY;
        bollX += directionX;
    }

    public List<int> getBallCurrentPosition() {
        return [bollX, bollY];
    }
}
}