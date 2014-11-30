import java.awt.Canvas;
import java.awt.Color;
import java.awt.Dimension;
import java.awt.Graphics;
import java.awt.image.BufferedImage;

/*
 * The main class that implements the functionality of the game
 */
@SuppressWarnings("serial")
public class Game extends Canvas implements Runnable {
	
	public static Snake snake;
	public static Apple apple;
	static int score;
	
	private Graphics globalGraphics;
	private Thread runThread;
	public static final int WIDTH = 600;
	public static final int HEIGHT = 600;
	private final Dimension playgroundDimensions = new Dimension(WIDTH, HEIGHT);
	
	/*
	 * field showing whether the game should continue
	 */
	static boolean gameRunning = false;
	
	/*
	 * A method which creates a new playground and sets the game as started.
	 */
	public void paint(Graphics g){
		this.setPreferredSize(playgroundDimensions);
		globalGraphics = g.create();
		score = 0;
		
		if(runThread == null){
			runThread = new Thread(this);
			runThread.start();
			gameRunning = true;
		}
	}
	
	/*
	 * If the game is running, the snake is being drawn with pauses of 100 ms.
	 */
	public void run(){
		while(gameRunning){
			snake.tick();
			render(globalGraphics);
			try {
				Thread.sleep(100);
			} catch (Exception e) {
				// TODO: fani ma za eksep6ana
			}
		}
	}
	
	/*
	 * A constructor which creates the game objects.
	 */
	public Game(){	
		snake = new Snake();
		apple = new Apple(snake);
	}
		
	// A method responsible for the rendering of all graphics.
	public void render(Graphics g){
		g.clearRect(0, 0, WIDTH, HEIGHT+25);
		g.drawRect(0, 0, WIDTH, HEIGHT);			
		snake.drawSnake(g);
		apple.drawApple(g);
		g.drawString("score= " + score, 10, HEIGHT + 25);		
	}
}

