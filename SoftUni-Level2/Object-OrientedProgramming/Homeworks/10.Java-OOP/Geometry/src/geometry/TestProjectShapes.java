package geometry;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

import geometry.interfaces.*;
import geometry.planeShapes.*;
import geometry.spaceShapes.*;

public class TestProjectShapes {

	public static void main(String[] args) {
		
		List<Shape> shapes = new ArrayList<Shape>();
		
		shapes.add(new Triangle(2, 6.4, 6, 15, 21, 20));
        shapes.add(new Rectangle(-15, 20, 5, 13));
        shapes.add(new Circle(2.5, 17, 8));
        
        shapes.add(new Cuboid(5, 6, -43, 5, 19, 28));
        shapes.add(new Sphere(20, -16, 7, 20));
        shapes.add(new SquarePyramid(5, 2, -4, 19, 2, 9));
               
        shapes.stream()
                .filter(s -> s instanceof VolumeMeasurable)
                .filter(v -> ((VolumeMeasurable)v).getVolume() > 40)
        		.forEach((s) -> System.out.println(s + "\n"));
        
        Comparator<Shape> orderByPerimeter = (s1, s2) -> Double.compare(
        		(((PlaneShape)s1).getPerimeter()),
        		(((PlaneShape)s2).getPerimeter()));
        
        shapes.stream()
		        .filter(s -> s instanceof PlaneShape)
		        .sorted(orderByPerimeter)
				.forEach((s) -> System.out.println(s + "\n"));
	}
	
}