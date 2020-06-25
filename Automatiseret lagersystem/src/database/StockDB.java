package database;

import java.sql.PreparedStatement;
import java.sql.ResultSet;

import database.DBConnection;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import controller.DataAccessException;
import database.DBConnection;
import model.Product;
import model.Stock;

public class StockDB implements StockDBIF {
	private static final String FIND_ALL_Q = "SELECT [productId]\r\n" + 
			"      ,[amount]\r\n" + 
			"      ,[minAmountSupply]\r\n" + 
			"      ,[storeid]\r\n" + 
			"  FROM [dmaa0918_1074167].[dbo].[stock]";
	private static final String Update_Q ="update stock\r\n" + 
			" set amount = ?\r\n" + 
			" \r\n" + 
			" where productId = ? and storeid = ?";
	private static final String FIND_BY_ID_Q = FIND_ALL_Q + " where storeid = ?";
	private PreparedStatement findByID, findall, UpdateStock;
	
	public StockDB() throws DataAccessException{
		try {
			findByID = DBConnection.getInstance().getConnection().prepareStatement(FIND_BY_ID_Q);
			findall = DBConnection.getInstance().getConnection().prepareStatement(FIND_ALL_Q);
			UpdateStock = DBConnection.getInstance().getConnection().prepareStatement(Update_Q);
		}catch(SQLException e) {
			throw new DataAccessException("could not prepare Satement", e);
		}
	}
	
	/*
	 * "buildObject" builds a stock with an amount, product IDs, and a minimum supply amount, which it then inserts into the system.
	 */
	
	private Stock buildObject(ResultSet rs) throws DataAccessException {
		Stock s = new Stock();
		try {
			s.setAmount(rs.getInt("amount"));
			s.setProduct(new Product(rs.getInt("productId")));
			s.setSupplyMinAmount(rs.getInt("minAmountSupply"));
			
		} catch (SQLException e) {
			throw new DataAccessException("could not read resultset", e);
		}
		return s;
	}
	private List<Stock> buildojects(ResultSet rs) throws DataAccessException{
		List<Stock> res = new ArrayList<>();
		try {
			while(rs.next()) {
				res.add(buildObject(rs));
			}
		} catch (SQLException e) {
			throw new DataAccessException("could not read result set", e);
		}
		return res;
	}
	
	/*
	 * "FindallStock" is a function that just finds all stocks in the system.
	 */
	
	@Override
	public List<Stock> FindallStock() throws DataAccessException {
		ResultSet rs;
		try {
			rs=findall.executeQuery();
			List<Stock> res =  buildojects(rs);
			return res;
		} catch (SQLException e) {
			throw new DataAccessException("counldn't retrive all store", e);
		}
		
	}

	/*
	 * "findbystoreId" is function that searches for a store by its ID.
	 */
	
	@Override
	public List<Stock> findbystoreId(String storeid) throws DataAccessException {
		List<Stock> res = null;
		try {
			findByID.setString(1, storeid);
			ResultSet rs = findByID.executeQuery();
			res = buildojects(rs);
			return res;
		} catch (SQLException e) {
			throw new DataAccessException("could not excute query", e);
		}
		
	}

	@Override
	public void Updatestock(int amount, int productId, int Storeid ) throws DataAccessException {
		// TODO Auto-generated method stub
		try {
			UpdateStock.setInt(1, amount);
			UpdateStock.setInt(2, productId);
			UpdateStock.setInt(3, Storeid);
		} catch (SQLException e) {
			throw new DataAccessException("could not update the stock", e);
		}
		return;
		
	}

	
}