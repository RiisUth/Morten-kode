package controller;

	import model.Stock;
	import model.Store;

	import java.util.ArrayList;
	import java.util.List;
	import controller.StockController;
	import database.StoreDB;
	import database.StoreDBIF;
	
public class StoreController {
	private StoreDBIF storeDB;
	private StockController stockcon;
	
	public StoreController () throws DataAccessException {
		storeDB = new StoreDB();	
		stockcon =  new StockController();
	}
	
	/*
	 * This method finds a list of all stores from the database.
	 */
	
	public List<Store> findAll() throws DataAccessException {
		List<Store> res = storeDB.FindAllStores();
		return res;
	}
	
	/*
	 * This method finds all stores with stocks from the database.
	 */
	
	public ArrayList<Store> findallstoreswtihstocks() throws DataAccessException {
		ArrayList<Store> res = (ArrayList<Store>) storeDB.FindAllStores();
		int i = 0;
		while (i < res.size()) {
			res.get(i).setStocks((ArrayList<Stock>) stockcon.findbystoreid(String.valueOf(res.get(i).getstoreId())));
		i++;
		}
		return res;
	}
	
	/*
	 * This method finds a store by ID and puts it into a list.
	 */
	
	public List<Store> findByIdToList(int id) throws DataAccessException {
		
		List<Store> res = null;
		Store rs = storeDB.FindByID(id);
		res.add(rs);
		return res;
	}
	
	/*
	 * This method finds a store by ID. 
	 */
	
	public Store findById(int id) throws DataAccessException{
		Store rs = storeDB.FindByID(id);
		return rs; 
	
	}
}
