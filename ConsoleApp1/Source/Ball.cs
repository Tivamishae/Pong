using System;



public class Ball {
    public int ballX;
    public int ballY;
    public int directionX;
    public int directionY;

    public Ball(Arena arena) 
    {
        this.ballX = arena.columns / 4;
        this.ballY = arena.rows / 4;

    }


    public void move() {
        ballY += directionX;
        ballX += directionY;
    }
    public int getballYPosition()
    {
        return ballY;
    }

    public List<int> getBallCurrentPosition() {
        return [ballX, ballY];
    }
}
