package model;

public class Stock  {
	private int amount;
	private int MinAmountsupply;
	private Product product;
	
	/* Initiates an instance of Stock using amount, supplyMinAmount and product */
	 public Stock(int amount, int supplyMinAmount, Product product) {
		this.amount = amount;
		this.product = product;
		this.MinAmountsupply = supplyMinAmount;
	}
	 /* Initiates an empty instance of Stock*/
	 public Stock() {
		 
	 }
	 /* Gets the amount of a Stock*/ 
	public int getAmount() {
		return amount;
	}
	/* Sets the amount of a Stock */ 
	public void setAmount(int amount) {
		this.amount = amount;
	}
	/* Gets the supplyMinAmount of a Stock */
	public int getSupplyMinAmount() {
		return MinAmountsupply;
	}
	/* Sets the supplyMinAmount of a Stock */ 
	public void setSupplyMinAmount(int supplyMinAmount) {
		this.MinAmountsupply = supplyMinAmount;
	}
	/* Gets the product of a Stock */
	public Product getProduct() {
		return product;
	}
	/* Sets the product of a Stock */
	public void setProduct(Product product) {
		this.product = product;
	}

}
