package database;
import database.DBConnection;
import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.SQLException;
import java.util.List;
import controller.DataAccessException;
import model.Store;
import java.sql.ResultSet;
import java.util.ArrayList;



public class StoreDB implements StoreDBIF {

	
	
	private static final String findAllQ = "SELECT [storeId]\r\n" + 
			"      ,[address]\r\n" + 
			"      ,[priorityCategory]\r\n" + 
			"	  ,dmaa0918_1074167.dbo.ZipCity.zip\r\n" + 
			"	  ,dmaa0918_1074167.dbo.ZipCity.city\r\n" + 
			"  FROM [dmaa0918_1074167].[dbo].[Store]\r\n" + 
			"  inner JOIN dmaa0918_1074167.dbo.ZipCity ON dmaa0918_1074167.dbo.Store.zip=dmaa0918_1074167.dbo.ZipCity.zip;" ;
	private static final String findByStoreID = findAllQ + " SELECT [storeId]\r\n" + 
			"      ,[address]\r\n" + 
			"      ,[priorityCategory]\r\n" + 
			"	  ,zip\r\n" + 
			"  FROM [dmaa0918_1074167].[dbo].[Store]\r\n" + 
			" where storeId = ?";
	private PreparedStatement findByID, findAll;		
	
	public StoreDB() throws DataAccessException{
		Connection con = DBConnection.getInstance().getConnection();
		try { 
			findAll = con.prepareStatement(findAllQ);
			findByID = con.prepareStatement(findByStoreID);
		}
		catch(SQLException e) { throw new DataAccessException("could not prepare statement",e);	
		}
	}
	
	/*
	 * "buildObject" builds a store with an address, its priority category, and a zip, which it then inserts into the system.
	 */
	
	private Store buildObject(ResultSet rs) throws DataAccessException {
		Store s = new Store();
		try { 
				s.setStoreId(rs.getInt("storeId"));
				s.setAddress(rs.getString("address"));
				s.setPriorityCategory(rs.getString("priorityCategory"));
				s.setZip(rs.getString("zip"));
				s.setCity(rs.getString("city"));
	} catch (SQLException e) {
		throw new DataAccessException("could not read resultset", e);
	}	
		return s;
		}
	private List<Store> buildObjects(ResultSet rs) throws DataAccessException{
	List<Store>	res = new ArrayList<>();
	try {
		while(rs.next()) {
		Store cuurStore = buildObject(rs);
		res.add(cuurStore);
		}
	} catch (SQLException e) {
		throw new DataAccessException("could not read resultset", e);
	}
	return res;	
	}

	/*
	 * "FindByID" finds a store by its ID.
	 */
		
	@Override
	public Store FindByID(int storeId) throws DataAccessException {
		Store currStore = null;
		
		try {
			findByID.setInt(1, storeId);
			ResultSet rs = findByID.executeQuery();
			if (rs.next()) {
				currStore = buildObject(rs);
			}
		} catch(SQLException e) {
			throw new DataAccessException("Could not find store", e);
		}
		return currStore;
	}

	/*
	 * "InsertStore" inserts a store into the database.
	 */
	
	@Override
	public Store InsertStore(Store store) {
		return null;
	}

	/*
	 * "FindByOrderId" finds an order by its ID in the database.
	 */
	
	@Override
	public Store FindByOrderId() {
		return null;
	}

	/*
	 * "FindAllStores" finds all stores with the same system.
	 */
	
	@Override
	public List<Store> FindAllStores() throws DataAccessException{
		ResultSet rs;
		try {
			rs=findAll.executeQuery();
			List<Store> res = buildObjects(rs);
			return res;
			}catch(SQLException e) {
			throw new DataAccessException("couldn't retrieve all stores",e);
		}
	}

}
