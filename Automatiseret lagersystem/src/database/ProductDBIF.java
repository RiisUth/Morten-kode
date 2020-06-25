package database;

import java.util.List;

import controller.DataAccessException;
import model.Product;

/*
 * "ProductDBIF" is just a database interface.
 */

public interface ProductDBIF {
	Product findById(int productId) throws DataAccessException;

	Product InsertProduct(Product product) throws DataAccessException;

	List<Product> findAllProducts() throws DataAccessException;
}
