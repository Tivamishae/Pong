using System;


namespace Ball {
    public class Ball {
    public int ballY;
    public int ballX;

    public int directionY;
    public int directionX;

    public void move() {
        ballY += directionY;
        ballX += directionX;
    }

    public List<int> getBallCurrentPosition() {
        return [ballX, ballY];
    }
}
}