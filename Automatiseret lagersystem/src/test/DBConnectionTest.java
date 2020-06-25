package test;

import static org.junit.Assert.assertNotNull;
import static org.junit.Assert.assertNull;

import org.junit.After;
import org.junit.Test;
import org.junit.jupiter.api.BeforeEach;

import database.DBConnection;

public class DBConnectionTest {
	
	DBConnection con = null;
	
/* Tests the connection to the database, is supposed to fail after printing out "was able to connect to database" in the console */

	
	
	@BeforeEach 
public void setup() {
System.out.println("setUP()");
try {
	con= DBConnection.getInstance();
} catch (Exception e) {
	// TODO Auto-generated catch block
	e.printStackTrace();
}
System.out.println("state of con: " + con.getConnection() + "/n");
}


	@Test
public void wasAbleToConnectToDatabase() {
	System.out.println("Was able to connect to database");
	assertNull("Connected - connection cannot be null", con);
	
	
	
	con.disconnect();
	// boolean wasNullified = con.instanceIsNull();
	 assertNull("disconnected - instance set to null", con.getConnection());
	
	try {
		con = DBConnection.getInstance();
	} catch (Exception e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}
	assertNotNull("connected - connection cannot be null",con);
	

}



	@After
public void cleanup() {
		System.out.println("cleanUp() /n");	
		con.disconnect();
}
}
