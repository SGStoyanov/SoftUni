package geometry;

public abstract class Shape {

	protected Vertex[] vertices;

	protected Shape() {
		this.vertices = new Vertex[1];
	}
	
	public Vertex[] getVertices() {
		return vertices;
	}

	public void setVertices(Vertex[] vertices) {
		this.vertices = vertices;
	}
	
	 @Override
	 public String toString() {
		 return this.vertices[0].toString();
	 }
	
}