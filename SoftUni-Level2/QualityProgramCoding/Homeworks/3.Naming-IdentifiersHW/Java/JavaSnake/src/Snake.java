import java.awt.Color;
import java.awt.Graphics;
import java.util.LinkedList;

public class Snake{
	LinkedList<SnakeEnlarged> snakeBody = new LinkedList<SnakeEnlarged>();
	private Color snakeColor;
	private int velocityX, velocityY;
	
	public Snake() {
		snakeColor = Color.GREEN;
		snakeBody.add(new SnakeEnlarged(300, 100)); 
		snakeBody.add(new SnakeEnlarged(280, 100)); 
		snakeBody.add(new SnakeEnlarged(260, 100)); 
		snakeBody.add(new SnakeEnlarged(240, 100)); 
		snakeBody.add(new SnakeEnlarged(220, 100)); 
		snakeBody.add(new SnakeEnlarged(200, 100)); 
		snakeBody.add(new SnakeEnlarged(180, 100));
		snakeBody.add(new SnakeEnlarged(160, 100));
		snakeBody.add(new SnakeEnlarged(140, 100));
		snakeBody.add(new SnakeEnlarged(120, 100));

		velocityX = 20;
		velocityY = 0;
	}
	
	public void drawSnake(Graphics g) {		
		for (SnakeEnlarged point : this.snakeBody) {
			point.draw(g, snakeColor);
		}
	}
	
	public void tick() {
		SnakeEnlarged snakePointNewPosition = new SnakeEnlarged((snakeBody.get(0).horizontalPositionX() + velocityX), (snakeBody.get(0).verticalPositionY() + velocityY));
		
		if (snakePointNewPosition.horizontalPositionX() > Game.WIDTH - 20) {
		 	Game.gameRunning = false;
		} else if (snakePointNewPosition.horizontalPositionX() < 0) {
			Game.gameRunning = false;
		} else if (snakePointNewPosition.verticalPositionY() < 0) {
			Game.gameRunning = false;
		} else if (snakePointNewPosition.verticalPositionY() > Game.HEIGHT - 20) {
			Game.gameRunning = false;
		} else if (Game.apple.addPoints().equals(snakePointNewPosition)) {
			snakeBody.add(Game.apple.addPoints());
			Game.apple = new Apple(this);
			Game.points += 50;
		} else if (snakeBody.contains(snakePointNewPosition)) {
			Game.gameRunning = false;
			System.out.println("You ate yourself");
		}	
		
		for (int i = snakeBody.size()-1; i > 0; i--) {
			snakeBody.set(i, new SnakeEnlarged(snakeBody.get(i-1)));
		}	
		snakeBody.set(0, snakePointNewPosition);
	}

	public int getVelocityX() {
		return velocityX;
	}

	public void setVelocityX(int velocityX) {
		this.velocityX = velocityX;
	}

	public int getVelocityY() {
		return velocityY;
	}

	public void setVelocityY(int velocityY) {
		this.velocityY = velocityY;
	}
}
