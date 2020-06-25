package model;

import java.time.LocalDate;
import java.util.Date;

public class Order {
	private String state;
	private LocalDate sentDate;
	private Product product;
	private Store store;
	private int orderId;

	/* Initiates an empty instance of Order */
	public Order() {
		
	}
	/* Initiates an instance of Order using product and store and auto generating orderId, state and sentDate */
	public Order(Product product, Store store) {
		this.product = product;
		this.store = store;
		setState("Shipped");
		setSentDate(LocalDate.now());
	}
	/* Initiates an instance of Order using orderId, State, sentDate, product and store */
	public Order(int orderId, String state, LocalDate sentDate, Product product, Store store) {
		this.sentDate = sentDate;
		this.state =  state;
		this.sentDate = sentDate;
		this.product = product;
		this.store = store;
		this.orderId = orderId;
	}
	/* Gets the orderId of an Order  */
	public int getOrderId() {
		return orderId;
	}
	/*  Sets the orderId of an Order  */
	public void setOrderId(int orderId) {
		this.orderId = orderId;
	}
	/* Gets the state of an Order  */
	public String getState() {
		return state; 
	}
	/* Sets the state of an Order */
	public void setState(String state) {
		this.state = state;
	}
	
	/* Sets the sentDate of an Order  */
	public LocalDate getSentDate() {
		return sentDate;
	}
	/* Sets the sentDate of an Order */
	public void setSentDate(LocalDate sentDate) {
		this.sentDate = sentDate;
	}
	/* Gets the product of an Order */
	public Product getProduct() {
		return product;
	}
	/* Sets the product of an Order  */
	public void setProduct(Product product) {
		this.product = product;
	}
	/* Gets the store of an Order   */
	public Store getStore() {
		return store;
	}
	/* Sets the store of an Order */
	public void setStore(Store store) {
		this.store = store;
	}

}
