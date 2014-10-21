package geometry.planeShapes;

import geometry.PlaneShape;
import geometry.Validation;

public class Rectangle extends PlaneShape {
	
	private double width;
	private double height;
	
	public Rectangle(double pointX, double pointY, double width, double height) {
		super(pointX, pointY);
		
		this.setWidth(width);
		this.setHeight(height);
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
	
	@Override
	public double getArea() {
		return this.width * this.height;
	}

	@Override
	public double getPerimeter() {
		return (2 * this.width) + (2 * this.height);
	}
	
}