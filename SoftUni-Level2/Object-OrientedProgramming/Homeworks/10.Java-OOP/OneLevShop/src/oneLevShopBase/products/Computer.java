package oneLevShopBase.products;

import oneLevShopBase.AgeRestriction;

public class Computer extends ElectronicsProduct {

	public Computer(String productName, double price, double quantity, AgeRestriction ageRestriction) {
		
		super(productName, price, quantity, ageRestriction);
		this.guaranteePeriod = 24;
		this.price = getProductPrice();
	}

	@Override
	public double getProductPrice() {
		
		if(this.quantity > 1000) {
			return this.price * 0.95;
		}
		
		return this.price;
	}
	
}