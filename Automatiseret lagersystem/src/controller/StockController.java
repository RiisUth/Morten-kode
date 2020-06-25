package controller;

	import java.util.List;
	import java.util.ArrayList;
	import controller.StoreController;
	import database.StockDBIF;
	import database.StockDB;
	import model.Stock;
import model.Store;

public class StockController  {
	private StockDBIF StockDB;
	ArrayList<Store> stores = new ArrayList<Store>();
	
	public StockController () throws DataAccessException {
		StockDB = new StockDB();
		
	}
	
	/*
	 * This method finds a list of all stocks from the database.
	 */
	
	public List<Stock> findAll() throws DataAccessException {
		List<Stock> res = StockDB.FindallStock();
		return res;
	}
	
	/*
	 * This method finds a stock by searching for the corresponding store ID,
	 * and puts it into a list.
	 */
	
	public List<Stock> findbystoreid(String storeid) throws DataAccessException {
		List<Stock> res = StockDB.findbystoreId(storeid);
		return res;
	}

	
	public void updateStock(int amount, int productId,int storid) throws DataAccessException {
		StockDB.Updatestock(amount, productId, storid);
	}
}
