using System;
using System.Security.Cryptography.X509Certificates;



public class Ball {
    public int ballY;
    public int ballX;
    public int directionY;
    public int directionX;
    public int xBounces = 0;

    public int yBounces = 0;

    public Ball(int x, int y) 
    {
        ballY = y;
        ballX = x;
        directionY = 1;
        directionX = 1;
    }

    public void resetBall(bool firstPlayerPoint)
    {
        if (firstPlayerPoint) {
            ballX = 76;
        }
        else {
            ballX = 4;
        }
        ballY = 10;
        directionX = 0;
        directionY = 0;
    }

    public void changeXDirection(int directionChange)
    {
        if (xBounces % 2 == 0) {
            directionX = -directionChange;
        }
        else {
            directionX = directionChange;
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
