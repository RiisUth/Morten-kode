package database;

import java.util.List;

import controller.DataAccessException;
import model.Stock;

/*
 * "StockDBIF" is just a database interface.
 */

public interface StockDBIF {

	List<Stock> FindallStock() throws DataAccessException;
	
	List<Stock> findbystoreId(String storeid) throws DataAccessException;
	
	void Updatestock(int amount, int productId, int Storeid) throws DataAccessException;
}
