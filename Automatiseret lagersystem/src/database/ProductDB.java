package database;


import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import controller.DataAccessException;
import model.Product;





public class ProductDB implements ProductDBIF {

	
	private static final String INSERTQ = "insert into product (description, name) values (?, ?)";
	private static final String FIND_All_Q = "SELECT [Description]\r\n" + 
			"      ,[name]\r\n" + 
			"      ,[productId]\r\n" + 
			"  FROM [dmaa0918_1074167].[dbo].[Product]";
	private static final String FIND_BY_ID_Q = FIND_All_Q + " where productId = ?";
	private PreparedStatement findByID, insertProduct, findAll;
	
	public ProductDB() throws DataAccessException {
		try  { 
			findByID = DBConnection.getInstance().getConnection().prepareStatement(FIND_BY_ID_Q);
			insertProduct = DBConnection.getInstance().getConnection().prepareStatement(INSERTQ);
			findAll = DBConnection.getInstance().getConnection().prepareStatement(FIND_All_Q);
		
		} catch (SQLException e) {
			throw new DataAccessException("could not prepare statement", e);	
		}	
	}
	
	/*
	 * "findById" is to find a product by its ID.
	 */
	
	@Override
	public Product findById(int productId) throws DataAccessException {
	Product p = null;
	try {
		findByID.setInt(1, productId);
		ResultSet rs = findByID.executeQuery();
		
		if(rs.next()) {
			p = buildObject(rs);
		}
		}catch (SQLException e) {
			
	}
		return p;
	}
	
	/*
	 * "InsertProduct" is to insert a new type of product in, with a description and a name into the system for availability.
	 */
	
	@Override
	public Product InsertProduct(Product product) throws DataAccessException {
		try {
		insertProduct.setString(1, product.getDescription());
		insertProduct.setString(2, product.getName());
	} catch (SQLException e) {
			throw new DataAccessException("could not find product to insert",e);
	} try {
			insertProduct.executeUpdate();
	}catch (SQLException e) {
		throw new DataAccessException("could not insert", e);
	}
	return product;
	}
	
	/*
	 * "findAllProducts" is basically a function which finds all products.
	 */
	
	@Override
	public List<Product> findAllProducts() throws DataAccessException {
		ResultSet rs;
		try { 
			rs = this.findAll.executeQuery();
			
		} catch (SQLException e) {
			throw new DataAccessException("could not excuate query", e);
		}
		List<Product> res = buildObjects(rs);
		return res;
		
	}
	
	/*
	 * "buildObject" is a function that builds a product with a description, name, and a product ID, which it then saves into the system.
	 */
	
	private Product buildObject(ResultSet rs) throws DataAccessException{
		Product p = new Product(); 

		try {
				
				p.setDescription(rs.getString("description"));
				p.setName(rs.getString("name"));
				p.setProductId(rs.getInt("productId"));
				
		} catch (SQLException e) {
			throw new DataAccessException("can't reed result set", e);	
		}
		return p; 
	}
	private List<Product> buildObjects(ResultSet rs) throws DataAccessException {
		List<Product> res = new ArrayList<>();
		try {
			while (rs.next()) {
				Product currProduct = buildObject(rs);
				res.add(currProduct);
			}
		} catch (SQLException e) {
			throw new DataAccessException("could not read resultset", e);
		}
		return res;
	}
}

