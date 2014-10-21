package geometry.spaceShapes;
import geometry.SpaceShape;
import geometry.Validation;;

public class SquarePyramid extends SpaceShape {
	private double baseWidth;
	private double height;
	private double slantHeight;
	
	public SquarePyramid(double pointX, double pointY, double pointZ,
						 double baseWidth, double height, double slantHeight) {
		
		super(pointX, pointY, pointZ);
		this.setBaseWidth(baseWidth);
		this.setHeight(height);
		this.setSlantHeight(slantHeight);
	}

	public double getBaseWidth() {
		return this.baseWidth;
	}

	public void setBaseWidth(double baseWidth) {
		Validation.checkDoubleValueForNegativeOrZeroInput(baseWidth);
		this.baseWidth = baseWidth;
	}

	public double getHeight() {
		return this.height;
	}

	public void setHeight(double height) {
		Validation.checkDoubleValueForNegativeOrZeroInput(height);
		this.height = height;
	}

	public double getSlantHeight() {
		return this.slantHeight;
	}

	public void setSlantHeight(double slantHeight) {
		Validation.checkDoubleValueForNegativeOrZeroInput(slantHeight);
		this.slantHeight = slantHeight;
	}
	
	private double getBaseArea() {
		return this.baseWidth * this.baseWidth;
	}
	
	@Override
	public double getArea() {
		double faceArea = (1.0 / 2.0) * (4 * this.baseWidth) * this.height;
		double baseArea = this.getBaseArea();	
		return faceArea + baseArea;
	}

	@Override
	public double getVolume() {
		return (1.0 / 3.0) * this.getBaseArea() * this.height;
	}

}