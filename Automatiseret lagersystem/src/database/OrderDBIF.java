package database;

import java.util.List;
import controller.DataAccessException;
import model.Order;

/*
 * "OrderDBIF" is just a database interface.
 */

public interface OrderDBIF {
	Order findById(int Id) throws DataAccessException;

	Order InsertOrder(Order order) throws DataAccessException;

	List<Order> findAllOrders() throws DataAccessException;

	List<Order> FindOrdersForStore(String StoreId) throws DataAccessException;
	
	List<Order> FindOrdersbyproductId(String productId) throws DataAccessException;
	
	List<Order> findOrdersByProductIdStoreid(String productId, String StoreId) throws DataAccessException;
}
