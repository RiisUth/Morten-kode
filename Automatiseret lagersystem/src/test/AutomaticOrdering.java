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
import controller.StockController;
import controller.DataAccessException;
import controller.OrderController;
import controller.DataAccessException;
/**
 * @author Morten Riis Uth
 *
 */
public class AutomaticOrdering {
	
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
		boolean pass = false;
			//orderstatus before the tread has run
		ArrayList<Order> orders = (ArrayList<Order>) OrderController.findAll();
		// act
		try {
			stockcontroller.updateStock(10, 2, 1);
			stockcontroller.updateStock(11, 1, 1);
			stockcontroller.updateStock(0, 3, 1);
			stockcontroller.updateStock(6, 1, 2);
			stockcontroller.updateStock(2, 4, 1);
		
			stockchecker.run();
			
		} catch (DataAccessException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		ArrayList<Order> neworders = (ArrayList<Order>) OrderController.findAll();
		
		//assert
		if (orders.size() - neworders.size() == 4) {
			pass = true;
		}
		assertTrue(pass);
	}
	
}
