import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

/*
 * A class responsible for construction of the snake and implements conditions for the game end.
 */
public class Snake{
	LinkedList<ApplePoint> snakeBody = new LinkedList<ApplePoint>();
	private Color snakeColor;
	private int velocityX, velocityY;
	
	// Defining the snake properties
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new ApplePoint(300, 100)); 
		snakeBody.add(new ApplePoint(280, 100)); 
		snakeBody.add(new ApplePoint(260, 100)); 
		snakeBody.add(new ApplePoint(240, 100)); 
		snakeBody.add(new ApplePoint(220, 100)); 
		snakeBody.add(new ApplePoint(200, 100)); 
		snakeBody.add(new ApplePoint(180, 100));
		snakeBody.add(new ApplePoint(160, 100));
		snakeBody.add(new ApplePoint(140, 100));
		snakeBody.add(new ApplePoint(120, 100));

		// initial speed and direction
		velocityX = 20;
		velocityY = 0;
	}
	
	public void drawSnake(Graphics g) {		
		for (ApplePoint applePoint : this.snakeBody) {
			applePoint.draw(g, snakeColor);
		}
	}
	
	/*
	 * A method which checks whether the current position of the snake isn't against the rules of the game. If they are, the game is over.
	 */
	public void tick() {
		ApplePoint snakePointNewPosition = new ApplePoint((snakeBody.get(0).applePointPositionX() + velocityX), (snakeBody.get(0).applePointPositionY() + velocityY));
		
		if (snakePointNewPosition.applePointPositionX() > Game.WIDTH - 20) {
		 	Game.gameRunning = false;
		} else if (snakePointNewPosition.applePointPositionX() < 0) {
			Game.gameRunning = false;
		} else if (snakePointNewPosition.applePointPositionY() < 0) {
			Game.gameRunning = false;
		} else if (snakePointNewPosition.applePointPositionY() > Game.HEIGHT - 20) {
			Game.gameRunning = false;
		} else if (Game.apple.getPoint().equals(snakePointNewPosition)) {
			snakeBody.add(Game.apple.getPoint());
			Game.apple = new Apple(this);
			Game.score += 50;
		} else if (snakeBody.contains(snakePointNewPosition)) {
			Game.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = snakeBody.size()-1; i > 0; i--) {
			snakeBody.set(i, new ApplePoint(snakeBody.get(i-1)));
		}	
		snakeBody.set(0, snakePointNewPosition);
	}

	// gets the current horizontal velocity
	public int getVelocityX() {
		return velocityX;
	}

	// sets the current horizontal velocity
	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

	// gets the current vertical velocity
	public int getVelocityY() {
		return velocityY;
	}

	// sets the current vertical velocity
	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}
}
