using System;



public class Ball {
    public int ballY;
    public int ballX;
    public int directionY;
    public int directionX;
    public int xBounces = 0;

    public int yBounces = 0;

    public Ball(int x, int y) 
    {
        this.ballY = y;
        this.ballX = x;
        this.directionY = 1;
        this.directionX = 1;
    }

    public void resetBall(Ball ballY)
    {
        this.ballY = 10;
        this.ballX = 40;
    }

    public void changeXDirection()
    {
        if (xBounces % 2 == 0) {
            directionX = -1;
        }
        else {
            directionX = 1;
        }
        xBounces += 1;
    }
    public void changeYDirection(int directionChange, bool wallBounce)
    {
        if (wallBounce == true) {
            yBounces += 1;
            directionY = directionY * directionChange;
        }
        else {
            if (yBounces % 2 == 0) {
                directionY = directionChange;
            }
            else {
                directionY = -directionChange;
            }
        }
        
    }
    public void move() { 

        ballY += directionY;
        ballX += directionX;
    }
    public int getBallXPosition()
    {
        return ballX;
    }

    public int getBallYPosition()
    {
        return ballY;
    }


}
