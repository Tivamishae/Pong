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

    public void changeYDirection()
    {
        directionY = directionY*(-1);
        
    }
    public void changeXDirection()
    {
        directionX = directionX*(-1);
        
    }
    public void move() { // Vi behöver fixa logik för bollen i X-led (upp och ner). Vi behöver även fixa logik för poäng när ballY == 0 eller 80, alltså att det blir mål

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
