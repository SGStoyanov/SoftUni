package oneLevShopBase.products;

import oneLevShopBase.AgeRestriction;
import oneLevShopBase.Product;
import oneLevShopBase.Validation;

public abstract class ElectronicsProduct extends Product {
	
	protected int guaranteePeriod;
	
	public ElectronicsProduct(String productName, double price, double quantity, 
							  AgeRestriction ageRestriction) {
		
			super(productName, price, quantity, ageRestriction);	

	}

	public int getGuaranteePeriod() {
		return guaranteePeriod;
	}

	public void setGuaranteePeriod(int guaranteePeriod) {
		Validation.checkIntegerForNegativeOrZeroInput(guaranteePeriod);
		this.guaranteePeriod = guaranteePeriod;
	}

	@Override
	public String toString() {
		
		return super.toString() + ", Guarantee Period " + this.guaranteePeriod;
	}
	
	public abstract double getProductPrice();

}