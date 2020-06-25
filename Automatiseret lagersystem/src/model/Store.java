package model;

import java.util.ArrayList;



public class Store {
	private String address;
	private String priorityCategory;
	private String zip;
	private int storeId;
	private String city;
	ArrayList<Stock> stocks= new ArrayList<Stock>();
	public Store() {
	}
	
	/* Initiates  an instance of Store using only the storeId to fill in the address, priorityCartgory and zip later */ 
	public Store(int storeId) {
		this.storeId = storeId;
		
	}
	/* Initiates an instance of Store using the storeId, address, priorityCategory, zip and stock*/ 
	public Store(int storeId, String address, String priorityCategory, String zip, Stock stock) {
		this.address = address;
		this.priorityCategory = priorityCategory;
		this.zip = zip;
		this.storeId = storeId;
		
	}

	/* Gets the address of a Store */
	
	public String getAddress() {
		return address;
	}
	/* Sets the address of a Store*/
	public void setAddress(String address) {
		this.address = address;
	}
	/* Gets the priorityCateogry of a Store */
	public String getPriorityCategory() {
		return priorityCategory;
	}
	/*  Sets the prioityCategory of a Store*/
	public void setPriorityCategory(String priorityCategory) {
		this.priorityCategory = priorityCategory;
	}

	/* Gets the zip code of a store*/
	public String getZip() {
		return zip;
	}
	
	/*Sets the zip code of a store */
	public void setZip(String zip) {
		this.zip = zip;
	}
	
	/* Gets the storeId of a store*/
	public int getstoreId() {
		return storeId;
	}
	/* adds stock status of a product to the Store*/
	public void addItems(Stock stock) {
		stocks.add(stock);
	}

	
	/* Sets a Store ID for a store when creating a new store */
	public void setStoreId(int storeId) {
		this.storeId = storeId;
	}

	public ArrayList<Stock> getStocks() {
		return stocks;
	}
	/* Sets a stock */
	public void setStocks(ArrayList<Stock> stocks) {
		this.stocks = stocks;
	}

	public String getCity() {
		return city;
	}

	public void setCity(String city) {
		this.city = city;
	}
	
}