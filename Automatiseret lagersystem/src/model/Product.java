package model;

public class Product {
	private String description;
	private String name;
	private int productId;
	
	/* Initiates an instance of Product using the productId without filling in the name or description */
	public Product(int productId) {
		this.productId = productId;
	}
/* initiates an empty instance of Product */
	public Product() {
	}

	/* Initiates an instance of Product using the description, name and productId*/ 
	public Product(String description, String name, int productId) {
		this.description = description;
		this.name = name;
		this.productId = productId;
	}
	/* Gets the description of a Product */ 
	public String getDescription() {
		return description;
	}
	/* Sets the description of a Product*/ 
	public void setDescription(String description) {
		this.description = description;
	}
	/* Gets the name of a Product*/ 
	public String getName() {
		return name;
	}
	/* Sets the name of a Product */
	public void setName(String name) {
		this.name = name;
	}
	/* Gets the productId of a Product*/
	public int getProductId() {
		return productId;
	}
	/* Sets the prdouctId of a Product */ 
	public void setProductId(int productId) {
			this.productId = productId;
}

	}
