package geometry.spaceShapes;
import geometry.SpaceShape;
import geometry.Validation;;


public class Sphere extends SpaceShape {
	private double radius;

	public Sphere(double pointX, double pointY, double pointZ, double radius) {
		super(pointX, pointY, pointZ);

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
		return 4.0 * Math.PI * Math.pow(this.radius, 2);
	}

	@Override
	public double getVolume() {
		return (4.0 / 3.0) * Math.PI * Math.pow(this.radius, 3);
	}

}