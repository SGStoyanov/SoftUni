package geometry.planeShapes;

import geometry.PlaneShape;
import geometry.Validation;

public class Circle extends PlaneShape {
	
	private double radius;

	public Circle(double pointX, double pointY, double radius) {
		super(pointX, pointY);
		this.setRadius(radius);
	}
	
	
	public double getRadius() {
		return this.radius;
	}

	public void setRadius(double radius) {
		Validation.checkDoubleValueForNegativeOrZeroInput(radius);
		this.radius = radius;
	}

	@Override
	public double getArea() {
		return Math.PI * (this.radius * this.radius);
	}

	@Override
	public double getPerimeter() {
		return 2.0 * Math.PI * this.radius;
	}
}