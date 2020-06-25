package database;

import database.DBConnection;
import java.sql.Connection;
import java.sql.Date;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

import model.Order;
import model.Product;
import model.Store;
import controller.DataAccessException;

public class OrderDB implements OrderDBIF {

	private static final String FIND_All_Q = "SELECT [orderId]\r\n" + 
			"      ,[sentDate]\r\n" + 
			"      ,[storeId]\r\n" + 
			"      ,[state]\r\n" + 
			"      ,[productId]\r\n" + 
			"  FROM [dmaa0918_1074167].[dbo].[Orders]";
	private static final String FIND_BY_ID_Q = FIND_All_Q + " where orderId = ?";
	private static final String INTERTQ = "insert into Orders (state, sentDate, storeId, productId) values (?, ?, ?, ?)";
	private static final String FIND_BY_STOREID = FIND_All_Q + " where orderId = ?";
	private static final String FIND_BY_PRODUCTID = FIND_All_Q + " where productId = ?";
	private static final String FIND_BY_PRODUCTID_AND_STOREID = FIND_All_Q + " where productId = ? AND storeId = ?";
	private PreparedStatement findAll, findbyId, insertps, findbbuStoreID, findbyproductId, findbySIDandPID;
	
	public OrderDB() throws DataAccessException {
		try {
			findAll = DBConnection.getInstance().getConnection().prepareStatement(FIND_All_Q);
			findbyId = DBConnection.getInstance().getConnection().prepareStatement(FIND_BY_ID_Q);
			insertps = DBConnection.getInstance().getConnection().prepareStatement(INTERTQ);
			findbbuStoreID = DBConnection.getInstance().getConnection().prepareStatement(FIND_BY_STOREID);
			findbyproductId = DBConnection.getInstance().getConnection().prepareStatement(FIND_BY_PRODUCTID);
			findbySIDandPID = DBConnection.getInstance().getConnection().prepareStatement(FIND_BY_PRODUCTID_AND_STOREID);
		} catch (SQLException e) {
			throw new DataAccessException("could not prepare Statements", e);
		}
			
		
	}
	
	/*
	 * This function finds an Order by its ID. 
	*/
	@Override
	public Order findById(int Id) throws DataAccessException {
		 Order o = null;
		 try {
			 findbyId.setInt(1, Id);
			 ResultSet rs = findbyId.executeQuery();
			 
			 if(rs.next()) {
				 o = buildObject(rs);
			 }
		 }catch (SQLException e) {
			 
		 }
		return o;
	}

	/*
	 * This function inserts an order into the Order.java with state, value, store, and product, if it isn't possible, 
	 * it'll either just tell "could not find ps to insert" or "could not insert".
	 */
	
	@Override
	public Order InsertOrder(Order order) throws DataAccessException {
		try {
			insertps.setString(1, order.getState());
			insertps.setDate(2, Date.valueOf(order.getSentDate()));
			insertps.setInt(3,order.getStore().getstoreId());
			insertps.setInt(4, order.getProduct().getProductId());
		} catch (SQLException e) {
			throw new DataAccessException("could not find ps to insert", e);
		}
		try {
			insertps.executeUpdate();
		} catch (SQLException e) {
			throw new DataAccessException("could not insert", e);
		}
		return order;
	}

	/*
	 * "findAllOrders" receives all orders from Order.java, 
	 * which basically gets all orders that exists in all systems that are specifically using this system.
	 */
	
	@Override
	public List<Order> findAllOrders() throws DataAccessException {
		ResultSet rs;
		try {
			rs = this.findAll.executeQuery();
			
		} catch (SQLException e) {
		throw new DataAccessException("could not read resultset", e);
		}
		List<Order> res = buildObjects(rs);
		return res;
	}

	/*
	 * "FindOrdersForStore" basically finds all orders specifically for one store.
	 */
	
	@Override
	public List<Order> FindOrdersForStore(String StoreId) throws DataAccessException {
		List<Order> res = null;
		try {
			findbbuStoreID.setString(1, StoreId);
			ResultSet rs = findbbuStoreID.executeQuery();
			res = buildObjects(rs);
		} catch (SQLException e) {
		throw new DataAccessException("could not excute query", e);
	}
		return res;
}
	
	/*
	 * "buildObject" builds an order with its ID, state, sent date, store ID, and product ID, which it then puts into a list.
	 */
	
	private Order buildObject(ResultSet rs) throws DataAccessException{
		Order o = new Order(); 
		try {
				o.setOrderId(rs.getInt("orderId"));
				o.setState(rs.getString("state"));
				o.setSentDate(rs.getDate("SentDate").toLocalDate());
				o.setStore(new Store(rs.getInt("storeId")));
				o.setProduct(new Product(rs.getInt("productId")));
				
		} catch (SQLException e) {
			throw new DataAccessException("can't reed result set", e);	
		}
		return o; 
			}
	private List<Order> buildObjects(ResultSet rs) throws DataAccessException {
		List<Order> res =  new ArrayList<>();
		try {
			while (rs.next()) {
				Order currOrder = buildObject(rs);
				res.add(currOrder);
			}
		}catch (SQLException e) {
			throw new DataAccessException("could not read resultset", e);
		}
		return res;
	}

	/*
	 * "FindOrdersbyproductId" is just finding a product by its ID.
	 */
	
	@Override
	public List<Order> FindOrdersbyproductId(String productId) throws DataAccessException {
		List<Order> res = null;
		try {
			findbyproductId.setString(1, productId);
			ResultSet rs = findbbuStoreID.executeQuery();
			res = buildObjects(rs);
		} catch (SQLException e) {
			throw new DataAccessException("could not excute query", e);
		}
		return res;
	}

	@Override
	public List<Order> findOrdersByProductIdStoreid(String productId, String StoreId) throws DataAccessException {
		List<Order> res = null;
		try {
			findbySIDandPID.setString(1, productId);
			findbySIDandPID.setString(2, StoreId);
			ResultSet rs = findbySIDandPID.executeQuery();
			res = buildObjects(rs);
		} catch (SQLException e) {
			throw new DataAccessException("could not excute query", e);
		}
		return res;
	}
}
	

	
