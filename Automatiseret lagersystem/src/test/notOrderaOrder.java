/**
 * this a junit 4 test, that test if the shockchecker's run method does create the apropite orders consering the state of the data base
 */
package test;

import static org.junit.Assert.*;

import java.awt.FlowLayout;
import java.util.ArrayList;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import org.junit.jupiter.params.shadow.com.univocity.parsers.common.fields.AllIndexesSelector;

import database.DBConnection;
import model.Order;
import controller.Stockchecker;
import controller.StoreController;
import controller.StockController;
import controller.DataAccessException;
import controller.OrderController;
import controller.DataAccessException;
/**
 * @author Morten Riis Uth
 *
 */
public class notOrderaOrder {
	StoreController storecontroller = null;
	StockController stockcontroller = null;
	Stockchecker stockchecker = null;
	OrderController OrderController = null;
	 DBConnection con = null;
	

	/**
	 * @throws java.lang.Exception
	 * here are we setting up the connection the database
	 * we are also setting auto comitting to be off we can roll back our test data from the database
	 */
	@Before
	public void setUp() throws Exception {
		con = DBConnection.getInstance();
		con.startTransaction();
		try {
			storecontroller = new StoreController();
			stockcontroller = new StockController();
			OrderController = new OrderController();
			stockchecker = new Stockchecker();
			
		} catch (DataAccessException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	/**
	 * @throws java.lang.Exception
	 * here we setting up the rollback after the test
	 */
	@After
	public void tearDown() throws Exception {
		con.rollbackTransaction();
	}

	@Test
	public void test() throws DataAccessException {
		//arrange
		OrderController.notifyMe(1, 1); //makeing sure there is a order in the database
		boolean pass = false;
			//orderstatus before the tread has r
		ArrayList<Order> orders = (ArrayList<Order>) OrderController.findAll();
		// act
		try {
			stockcontroller.updateStock(11, 1, 1); //updateing the stock if it needs to happen
			
			
			stockchecker.run();
			
		} catch (DataAccessException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		ArrayList<Order> neworders = (ArrayList<Order>) OrderController.findAll();
		
		//assert
		if (orders.size() == neworders.size()) {
			pass = true;
		}
		assertTrue(pass);
	}
	
}
