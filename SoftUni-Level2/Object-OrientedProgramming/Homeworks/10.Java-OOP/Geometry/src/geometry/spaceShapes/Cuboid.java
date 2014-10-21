package geometry.spaceShapes;
import geometry.SpaceShape;
import geometry.Validation;

public class Cuboid extends SpaceShape {
	
	private double width;
	private double height;
	private double depth;
	
	public Cuboid(double pointX, double pointY, double pointZ, 
			double width, double height, double depth) {
		super(pointX, pointY, pointZ);
		
		this.setWidth(width);
		this.setHeight(height);
		this.setDepth(depth);
	}

	public double getWidth() {
		return this.width;
	}

	public void setWidth(double width) {
		Validation.checkDoubleValueForNegativeOrZeroInput(width);		
		this.width = width;
	}

	
	public double getHeight() {
		return this.height;
	}

	public void setHeight(double height) {
		Validation.checkDoubleValueForNegativeOrZeroInput(height);
		this.height = height;
	}

	public double getDepth() {
		return this.depth;
	}

	public void setDepth(double depth) {
		Validation.checkDoubleValueForNegativeOrZeroInput(depth);
		this.depth = depth;
	}
	
	@Override
	public double getArea() {
		return (this.width * this.depth +
				this.width * this.height +
				this.height * this.depth);
	}

	@Override
	public double getVolume() {
		return this.width * this.height * this.depth;
	}
	
}