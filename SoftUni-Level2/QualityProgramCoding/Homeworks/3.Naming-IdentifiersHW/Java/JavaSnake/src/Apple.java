import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;


public class Apple {
	public static Random randomGenerator;
	private SnakeEnlarged appleObject;
	private Color snakeColor;
	
	public Apple(Snake currentSnake) {
		appleObject = addAppleToSnake(currentSnake);
		snakeColor = Color.RED;		
	}
	
	private SnakeEnlarged addAppleToSnake(Snake currentSnake) {
		randomGenerator = new Random();
		int x = randomGenerator.nextInt(30) * 20; 
		int y = randomGenerator.nextInt(30) * 20;
		for (SnakeEnlarged snakePoint : currentSnake.snakeBody) {
			if (x == snakePoint.horizontalPositionX() || y == snakePoint.verticalPositionY()) {
				return addAppleToSnake(currentSnake);				
			}
		}
		return new SnakeEnlarged(x, y);
	}
	
	public void drawApple(Graphics appleGraphic){
		appleObject.draw(appleGraphic, snakeColor);
	}	
	
	public SnakeEnlarged addPoints(){
		return appleObject;
	}
}
