package geometry;

public abstract class Vertex extends Shape {

	protected double pointX;
	protected double pointY;
	
	public Vertex(double pointX, double pointY) {
		this.pointX = pointX;
		this.pointY = pointY;
	}

	public double getPointX() {
		return pointX;
	}

	public void setPointX(double pointX) {
		this.pointX = pointX;
	}

	public double getPointY() {
		return pointY;
	}

	public void setPointY(double pointY) {
		this.pointY = pointY;
	}
	
	public static double claculateDistancePointXPointY(Vertex...vertices){
		double sumDistance = 0;
		for (int i = 1; i < vertices.length; i++) {
			double differencePointXPointY = 
					Math.pow(vertices[i].getPointX() - vertices[i-1].getPointX(), 2)+
					Math.pow(vertices[i].getPointY() - vertices[i-1].getPointY(), 2);
			sumDistance +=differencePointXPointY;
		}
		double distance = Math.sqrt(sumDistance);
		return distance;
		
	}
	
	@Override
	public String toString() {
		return "point X = " + this.pointX + ", point Y = " + this.pointY;
	}
	
}