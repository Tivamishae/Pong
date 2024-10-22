using System;



public class Ball {
    public int ballX;
    public int ballY;
    public int directionX;
    public int directionY;

    public Ball(int x, int y) 
    {
        this.ballX = x;
        this.ballY = y;
        this.directionX = 1;
        this.directionY = 1;
    }

    public void resetBall(Ball ball)
    {
        this.ballX = 10;
        this.ballY = 40;
    }

    public void changeYDirection(int dir)
    {
        directionY = (dir);
        
    }
    public void changeXDirection(int dir)
    {
        directionX = directionX*(dir);
        
    }
    public void move() { 

        ballX += directionX;
        ballY += directionY;
    }
    public int getballYPosition()
    {
        return ballY;
    }

    public int getballXPosition()
    {
        return ballX;
    }


}
