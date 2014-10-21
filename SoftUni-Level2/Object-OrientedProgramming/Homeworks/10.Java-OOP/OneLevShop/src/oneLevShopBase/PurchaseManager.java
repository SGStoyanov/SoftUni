package oneLevShopBase;

import oneLevShopBase.interfaces.Expirable;
import oneLevShopBase.products.FoodProduct;

public class PurchaseManager {
	
	public static void ProcessPurchase(Customer customer, Product product) {
		
		double balanceAfterPurchase = customer.getCustomerBalance() - product.getProductPrice();
		
		if (balanceAfterPurchase <= 0 || customer.getCustomerBalance() < product.getProductPrice()) {
			System.out.println("You do not have enough money to buy this product!!");
		} else {
			customer.setCustomerBalance(balanceAfterPurchase);
		}	
		
		double quantityAfterPurchase = product.getProductQuantity() - 1;
		
		if (quantityAfterPurchase <= 0) {
			System.out.println("The product is out of stock!");
		} else {
			product.setProductQuantity(quantityAfterPurchase);
		}		
		
		if ((product instanceof Expirable) && ((FoodProduct)product).getDaysLeft() == 0) {
			System.out.println("The product is expirated!");
					
		} else if (product.getAgeRestriction() == AgeRestriction.Adult && 
				   customer.getCustomerAge() < 18) {
			System.out.println("You are too young to buy this product!");
		}
		
	}
}