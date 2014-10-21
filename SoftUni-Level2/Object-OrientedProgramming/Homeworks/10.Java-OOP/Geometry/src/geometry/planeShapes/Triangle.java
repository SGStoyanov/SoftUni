package geometry.planeShapes;

import geometry.PlaneShape;
import geometry.Vertex;
import geometry.Vertex2D;

public class Triangle extends PlaneShape {

	public Triangle(double pointX1, double pointY1, double pointX2, double pointY2,
					double pointX3, double pointY3) {
					super(pointX1, pointY1);
		
		this.vertices[1] = new Vertex2D(pointX2, pointY2);
		this.vertices[2] = new Vertex2D(pointX3, pointY3);
		this.isValidTriangle();
	}
	
	private double calculateSideA() {
		double sideA = Vertex.claculateDistancePointXPointY(this.vertices[0], this.vertices[1]);
		return sideA;
	}
	
	private double calculateSideB() {
		double sideB = Vertex.claculateDistancePointXPointY(this.vertices[1], this.vertices[2]);
		return sideB;
	}
	
	private double calculateSideC() {
		double sideC = Vertex.claculateDistancePointXPointY(this.vertices[2], this.vertices[0]);	
		return sideC;
	}
	
	private void isValidTriangle() {
		if(this.calculateSideA() >= this.calculateSideB() + this.calculateSideC() ||
			this.calculateSideB() >= this.calculateSideA() + this.calculateSideC() ||
			this.calculateSideC() >= this.calculateSideA() + this.calculateSideB()) {
			
			throw new IllegalArgumentException("Your incoming data does not form a triangle!");
		}		
	}
	
	@Override
	public double getArea() {
		double p = 
				(this.calculateSideA() + 
				this.calculateSideB() + 
				this.calculateSideC()) / 2;
		
        double trinagleArea = 
        		Math.sqrt(p * 
				(p - this.calculateSideA()) * 
				(p - this.calculateSideB()) * 
				(p - this.calculateSideC()));
        
        return trinagleArea;
	}

	@Override
	public double getPerimeter() {
		double trianglePerimeter = (this.calculateSideA() + this.calculateSideB() + this.calculateSideC());		
		return trianglePerimeter;
	}
	
}