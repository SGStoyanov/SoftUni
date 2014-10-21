package geometry;
public class Validation {
	
	public static void validateCustomerName(String value)
    {
        if (value.isEmpty() || value == null || (value.contains("[^a-zA-Z]")) || value.length() < 3) {
        	throw new NullPointerException("Ivalid or empty name!");
        }
        
    }
	
	public static void checkDoubleValueForNegativeOrZeroInput(double value) {
		if (value <=0) {
			throw new NullPointerException("Value can't be negative or equal to zero!");
		}
	}
	
	public static void checkInetegerForNegativeOrZeroInput(int value) {
		if (value <=0) {
			throw new NullPointerException("Value can't be negative or equal to zero!");
		}
	}
	
	public static void validateProductName(String value) {
		if(value.isEmpty() || value.equals(null)) {
			throw new NullPointerException("Ivalid or empty name!");
		}
	}
	
}