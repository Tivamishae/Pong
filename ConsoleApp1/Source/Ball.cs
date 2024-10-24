using System;



public class Ball {
    public int ballX;
    public int ballY;
    public int directionX;
    public int directionY;

    public Ball(Arena arena) 
    {
        this.ballX = arena.getRows() / 2;
        this.ballY = arena.getColumns() / 2;
        this.directionX = 1;
        this.directionY = 1;
    }

    public void resetBall(Ball ball)
    {
        this.ballX = 10;
        this.ballY = 40;
    }

    public void changeYDirection()
    {
        directionY = directionY*(-1);
        
    }
    public void changeXDirection()
    {
        directionX = directionX*(-1);
        
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
