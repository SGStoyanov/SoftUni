import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

public class SnakeEnlarged {
	private int x, y;
	private final int WidH = 20;
	private final int HeigT = 20;
	
	public SnakeEnlarged(SnakeEnlarged p){
		this(p.x, p.y);
	}
	
	public SnakeEnlarged(int x, int y){
		this.x = x;
		this.y = y;
	}	
		
	public int horizontalPositionX() {
		return x;
	}
	public void namestiXiksa(int x) {
		this.x = x;
	}
	public int verticalPositionY() {
		return y;
	}
	public void namestIgreka(int y) {
		this.y = y;
	}
	
	public void draw(Graphics graphic, Color color) {
		graphic.setColor(Color.BLACK);
		graphic.fillRect(x, y, WidH, HeigT);
		graphic.setColor(color);
		graphic.fillRect(x+1, y+1, WidH-2, HeigT-2);		
	}
	
	public String toString() {
		return "[x=" + x + ",y=" + y + "]";
	}
	
	public boolean equals(Object object) {
        if (object instanceof SnakeEnlarged) {
            SnakeEnlarged point = (SnakeEnlarged)object;
            return (x == point.x) && (y == point.y);
        }
        return false;
    }
}
