using System;



    public class Ball {
    public int ballX;
    public int ballY;

    public Ball(int x, int y) 
    {
        this.ballX = x;
        this.ballY = y;
    }

    public int directionX;
    public int directionY;

    public void move() {
        ballY += directionX;
        ballX += directionY;
    }

    public List<int> getBallCurrentPosition() {
        return [ballX, ballY];
    }
}
