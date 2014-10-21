package oneLevShopBase;

import java.text.ParseException;
import java.util.ArrayList;
import java.util.Comparator;
import java.util.List;

import oneLevShopBase.interfaces.Expirable;
import oneLevShopBase.products.*;

public class TestOneLevShopProject {

	public static void main(String[] args) throws ParseException{
		
		Customer montana = new Customer("Tony Montana", (byte) 15, 400);
		Appliance sdCard = new Appliance("usb", 65.66, 49, AgeRestriction.Teenager);
		
		PurchaseManager.ProcessPurchase(montana, sdCard);
		System.out.printf(montana.getCustomerName() + "\nBalance: %.2f lv.\n", montana.getCustomerBalance());
		System.out.println();
		
		List<Product> products = new ArrayList<Product>();
		
		products.add(new FoodProduct("tomato", 1.45, 15, AgeRestriction.None, "2014-11-01"));
		products.add(new FoodProduct("juice", 1.99, 12, AgeRestriction.None, "2014-11-20"));
		products.add(new Computer("Lenovo", 1959.50, 6, AgeRestriction.Adult));
		products.add(new Appliance("cpu fan", 150.00, 50, AgeRestriction.Teenager));

		Comparator<Product> byExpiryDate = (p1, p2) -> Long.compare(
				((FoodProduct) p1).getDaysLeft(), ((FoodProduct) p2).getDaysLeft());
		
		products.stream()
				.filter(p -> p instanceof Expirable)
				.sorted(byExpiryDate)
				.forEach((p) -> System.out.printf("%s expires in %s days\n", 
						(((FoodProduct) p).getProductName()), ((FoodProduct) p).getDaysLeft()));		
		
		Comparator<Product> orderByPrice = (s1, s2) -> Double.compare(s1.getProductPrice(), s2.getProductPrice());
		
		products.stream()
				.filter(p -> p.getAgeRestriction() == AgeRestriction.Adult)
				.sorted(orderByPrice)
				.forEach((p) -> System.out.println((Product) p));
	}

}