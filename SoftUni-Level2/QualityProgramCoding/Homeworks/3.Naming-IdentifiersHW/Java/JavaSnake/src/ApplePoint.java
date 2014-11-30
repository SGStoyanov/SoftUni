import java.awt.Color;
import java.awt.Graphics;
import java.awt.Rectangle;

/*
 * A class which implements the ApplePoint's methods and properties.
 */
public class ApplePoint {
	private int x, y;
	private final int width = 20;
	private final int height = 20;
	
	/*
	 * A method that sets the horizontal and vertical coordinates of an Apple.
	 */
	public ApplePoint(ApplePoint p){
		this(p.x, p.y);
	}
	
	/*
	 * A method used for the same thing and implemented by the above method.
	 */
	public ApplePoint(int x, int y){
		this.x = x;
		this.y = y;
	}	
	
	/*
	 * A public property for assigning the horizontal position of the Apple Point
	 */
	public int applePointPositionX() {
		return x;
	}
	
	/*
	 * A method for assigning the horizontal position of the Apple Point
	 */
	public void getApplePointXPosition(int x) {
		this.x = x;
	}
	
	/*
	 * A public property for assigning the vertical position of the Apple Point
	 */
	public int applePointPositionY() {
		return y;
	}
	
	/*
	 * A method for assigning the vertical position of the Apple Point
	 */
	public void getApplePointYPosition(int y) {
		this.y = y;
	}
	
	/*
	 * A method that draws the Apple Point with constant color to the coordinates retrieved by the above methods and properties.
	 */
	public void draw(Graphics graphic, Color color) {
		graphic.setColor(Color.BLACK);
		graphic.fillRect(x, y, width, height);
		graphic.setColor(color);
		graphic.fillRect(x+1, y+1, width-2, height-2);		
	}
	
	/*
	 * An override for printing the coordinates as a string
	 */
	public String toString() {
		return "[x=" + x + ", y=" + y + "]";
	}
	
	/*
	 * A method which checks whether the checked object is of instance ApplePoint. If yes, it returns the coordinates of the point.
	 */
	public boolean equals(Object object) {
        if (object instanceof ApplePoint) {
            ApplePoint applePoint = (ApplePoint)object;
            return (x == applePoint.x) && (y == applePoint.y);
        }
        return false;
    }
}