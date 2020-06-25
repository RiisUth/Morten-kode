package controller;

import model.Order;
import model.Product;
import model.Store;

import java.util.List;
import database.OrderDB;
import database.OrderDBIF;
import database.StoreDB;
import controller.StoreController;
import controller.ProductController;

public class OrderController implements Observer {
	private OrderDBIF orderDB;
	private StoreController Sctr;
	private ProductController Pctr;

public OrderController ()   throws DataAccessException  {
	orderDB = new OrderDB();
	Sctr = new  StoreController();
	Pctr = new ProductController();
}

public Order orderInsert(Order order) throws DataAccessException{
	Order ord = orderDB.InsertOrder(order);
	return ord;
}
/*
 * This method finds a list of all orders in the database.
 */

public List<Order> findAll() throws DataAccessException {
	List<Order> res = orderDB.findAllOrders();
return res; 
}

/*
 * This method finds an order by ID. 
 */

public List<Order> findById(int id) throws DataAccessException {
	List<Order> res = null;
	Order rs = orderDB.findById(id);
	res.add(rs);
	return res;
}

/* This method finds a product by its ID with a store ID */

public List<Order> findByProductIDStoreID(int productid, int StoreID) throws DataAccessException {
	
	List<Order> res = orderDB.findOrdersByProductIdStoreid(String.valueOf(productid), String.valueOf(StoreID));
	return res;
}

@Override
public void notifyMe(int productID, int storeId) {
	// TODO Auto-generated method stub
	try {
		Store currStore = Sctr.findById(storeId);
		Product currProduct = Pctr.findById(productID);
		Order neworder = new Order(currProduct, currStore);
		orderInsert(neworder);
	} catch (DataAccessException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
	
	
}


}