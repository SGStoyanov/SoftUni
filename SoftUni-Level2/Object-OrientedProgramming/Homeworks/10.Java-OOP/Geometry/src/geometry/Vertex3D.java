package geometry;

public class Vertex3D extends Vertex {
	
	private double pointZ;

	public Vertex3D(double pointX, double pointY, double pointZ) {
		super(pointX, pointY);
		this.pointZ = pointZ;
	}
	
	public double getPointZ() {
		return pointZ;
	}

	public void setPointZ(double pointZ) {
		this.pointZ = pointZ;
	}
	
	@Override
	public String toString() {
		return super.toString() + ", point Z = " + this.pointZ;
	}

}