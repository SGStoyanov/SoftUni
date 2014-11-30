import java.awt.Color;
import java.awt.Graphics;
import java.util.Random;

/*
 * The class that is responsible for the random creation of apples on the playground and for adding of the caught apples 
 * to the snake's body. 
 */
public class Apple {
	
	/*
	 * field used for the randomization of the coordinates of the new apples
	 */
	public static Random randomGenerator;
	private ApplePoint appleObject;
	/*
	 * a field keeping the snake color
	 */
	private Color snakeColor;
	
	/*
	 * A public constructor that creates new Apple objects.
	 */
	public Apple(Snake currentSnake) {
		appleObject = createApple(currentSnake);
		snakeColor = Color.RED;		
	}
	
	/*
	 * A method for creating of new apples. If the location of the new apple corresponds to the snake location, the apple is added to the snake. If not, it is only created on random location.
	 */
	private ApplePoint createApple(Snake currentSnake) {
		randomGenerator = new Random();
		int x = randomGenerator.nextInt(30) * 20; 
		int y = randomGenerator.nextInt(30) * 20;
		for (ApplePoint snakePoint : currentSnake.snakeBody) {
			if (x == snakePoint.applePointPositionX() || y == snakePoint.applePointPositionY()) {
				return createApple(currentSnake);				
			}
		}
		return new ApplePoint(x, y);
	}
	
	/*
	 * A method for the actual drawing of the apple on the field.
	 */
	public void drawApple(Graphics appleGraphic){
		appleObject.draw(appleGraphic, snakeColor);
	}	
	
	/*
	 *  A method for getting the apple's position
	 */
	public ApplePoint getPoint(){
		return appleObject;
	}
}