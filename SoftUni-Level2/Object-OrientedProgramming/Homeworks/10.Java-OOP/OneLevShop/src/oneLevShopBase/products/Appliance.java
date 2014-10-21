package oneLevShopBase.products;

import oneLevShopBase.AgeRestriction;

public class Appliance extends ElectronicsProduct {

	public Appliance(String productName, double price, double quantity, 
					 AgeRestriction ageRestriction) {
		
		super(productName, price, quantity, ageRestriction);
		
		this.guaranteePeriod = 6;
		this.price = getProductPrice();
	}

	@Override
	public double getProductPrice() {
		
		if (this.quantity < 50) {
			return this.price * 1.05;
		}
		
		return this.price;
	}

}