import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;

public class KeysCatcher implements KeyListener{
	
	public KeysCatcher(Game game){
		game.addKeyListener(this);
	}
	
	public void keyPressed(KeyEvent e) {
		int buttonCode = e.getKeyCode();
		
		if (buttonCode == KeyEvent.VK_W || buttonCode == KeyEvent.VK_UP) {
			if(Game.currentSnake.getVelocityY() != 20){
				Game.currentSnake.setVelocityX(0);
				Game.currentSnake.setVelocityY(-20);
			}
		}
		if (buttonCode == KeyEvent.VK_S || buttonCode == KeyEvent.VK_DOWN) {
			if(Game.currentSnake.getVelocityY() != -20){
				Game.currentSnake.setVelocityX(0);
				Game.currentSnake.setVelocityY(20);
			}
		}
		if (buttonCode == KeyEvent.VK_D || buttonCode == KeyEvent.VK_RIGHT) {
			if(Game.currentSnake.getVelocityX() != -20){
			Game.currentSnake.setVelocityX(20);
			Game.currentSnake.setVelocityY(0);
			}
		}
		if (buttonCode == KeyEvent.VK_A || buttonCode == KeyEvent.VK_LEFT) {
			if(Game.currentSnake.getVelocityX() != 20){
				Game.currentSnake.setVelocityX(-20);
				Game.currentSnake.setVelocityY(0);
			}
		}
		//Other controls
		if (buttonCode == KeyEvent.VK_ESCAPE) {
			System.exit(0);
		}
	}
	
	public void keyReleased(KeyEvent keyReleased) {
	}
	
	public void keyTyped(KeyEvent keyPressed) {
		
	}

}
