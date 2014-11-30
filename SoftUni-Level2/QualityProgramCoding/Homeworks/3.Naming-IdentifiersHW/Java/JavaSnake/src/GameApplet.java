import java.applet.Applet;
import java.awt.Dimension;
import java.awt.Graphics;

/*
 * A class responsible for the initialization of the game
 */
@SuppressWarnings("serial")
public class GameApplet extends Applet {
	private Game game;
	KeysCatcher keysCatcher;
	
	/*
	* Setting up the main variables and starting the keys listener (keysKatcher).
	*/
	public void init(){
		game = new Game();
		game.setPreferredSize(new Dimension(800, 650));
		game.setVisible(true);
		game.setFocusable(true);
		this.add(game);
		this.setVisible(true);
		this.setSize(new Dimension(800, 650));
		keysCatcher = new KeysCatcher(game);
	}
	
	// A method which sets the playground size
	public void paint(Graphics graphic){
		this.setSize(new Dimension(800, 650));
	}

}