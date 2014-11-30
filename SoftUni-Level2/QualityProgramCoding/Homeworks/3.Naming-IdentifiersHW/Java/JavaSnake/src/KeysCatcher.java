import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

/*
 * A class which implements the keys listeners and responses
 */
public class KeysCatcher implements KeyListener{
	
	public KeysCatcher(Game game){
		game.addKeyListener(this);
	}
	
	/*
	 * A method which checks which direction is pressed.
	 */
	public void keyPressed(KeyEvent e) {
		int buttonCode = e.getKeyCode();
		
		// If the W key is pressed, moves the snake upwards
		if (buttonCode == KeyEvent.VK_W || buttonCode == KeyEvent.VK_UP) {
			if(Game.snake.getVelocityY() != 20){
				Game.snake.setVelocityX(0);
				Game.snake.setVelocityY(-20);
			}
		}
		
		// If the S key is pressed, moves the snake downwards
		if (buttonCode == KeyEvent.VK_S || buttonCode == KeyEvent.VK_DOWN) {
			if(Game.snake.getVelocityY() != -20){
				Game.snake.setVelocityX(0);
				Game.snake.setVelocityY(20);
			}
		}
		
		// If the D key is pressed, points to the snake to the right
		if (buttonCode == KeyEvent.VK_D || buttonCode == KeyEvent.VK_RIGHT) {
			if(Game.snake.getVelocityX() != -20){
			Game.snake.setVelocityX(20);
			Game.snake.setVelocityY(0);
			}
		}
		
		// If the A key is pressed, points to the snake to the left
		if (buttonCode == KeyEvent.VK_A || buttonCode == KeyEvent.VK_LEFT) {
			if(Game.snake.getVelocityX() != 20){
				Game.snake.setVelocityX(-20);
				Game.snake.setVelocityY(0);
			}
		}
		
		//Other controls
		// If Escape is pressed the game is stopped.
		if (buttonCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	/* 
	 * A method which checks whether the key is released.
	 */
	public void keyReleased(KeyEvent keyReleased) {
	}
	
	/*
	 * A method which records the pressed key.
	 */
	public void keyTyped(KeyEvent keyPressed) {
		
	}

}
