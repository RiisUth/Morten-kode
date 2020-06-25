package controller;

import java.util.List;

import database.ProductDB;
import database.ProductDBIF;
import model.Product;

public class ProductController {
private ProductDBIF productDB;

public ProductController () throws DataAccessException {
	productDB = new ProductDB();
	
}

/*
 * This method finds a list of all products from the database.
 */

public List<Product>findAll() throws DataAccessException {
List<Product> res = productDB.findAllProducts();

return res;
}

/*
 * This method finds a product by ID and puts it into a list. 
 */

public List<Product> findByIdToList(int id) throws DataAccessException {
	List<Product> res = null;
	Product rs = productDB.findById(id);
	res.add(rs);
	return res;
}

/*
 * This method finds a product by ID. 
 */

	public Product findById(int id) throws DataAccessException{
		Product rs= productDB.findById(id);
		return rs;
	}
}
