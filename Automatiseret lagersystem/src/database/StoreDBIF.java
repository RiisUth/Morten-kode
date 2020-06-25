package database;

import java.sql.SQLException;
import java.util.List;

import controller.DataAccessException;
import model.Store;

/*
 * "StoreDBIF" is just a database interface.
 */

public interface StoreDBIF {
	Store FindByID(int storeId) throws DataAccessException;

	Store InsertStore(Store store);

	Store FindByOrderId() throws DataAccessException;

	List<Store> FindAllStores() throws DataAccessException;

}
