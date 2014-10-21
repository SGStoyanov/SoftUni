package oneLevShopBase;

public class Customer {

	private String name;
	private byte age;
	private double balance;
	
	public Customer(String customerName, byte customerAge, double customerBalance) {
		this.setCustomerName(customerName);
		this.setCustomerAge(customerAge);
		this.setCustomerBalance(customerBalance);
	}

	public String getCustomerName() {
		return name;
	}

	public void setCustomerName(String name) {
		Validation.validateCustomerName(name);
		this.name = name;
	}

	public byte getCustomerAge() {
		return age;
	}

	public void setCustomerAge(byte age) {
		Validation.checkIntegerForNegativeOrZeroInput(age);
		this.age = age;
	}

	public double getCustomerBalance() {
		return balance;
	}

	public void setCustomerBalance(double balance) {
		this.balance = balance;
	}
	
	@Override
	public String toString() {
		
		return "Customer:\n"+ this.name + "\nAge: " + this.age + "\nBalance: " + this.balance + "lv.";
	}
	
}