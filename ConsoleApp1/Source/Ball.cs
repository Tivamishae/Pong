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

    public void changeDirection()
    {
        directionY = directionY*(-1);
        
    }
    public void move() { // Vi behöver fixa logik för bollen i X-led (upp och ner). Vi behöver även fixa logik för poäng när ballY == 0 eller 80, alltså att det blir mål

       /*  if (ballY > 0 && ballY < 80) {
            ballY += directionY;
        }
        else {
            directionY = directionY*(-1);
            ballY += directionY;
        } */
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

    public List<int> getBallCurrentPosition() {
        return [ballX, ballY];
    }
}
