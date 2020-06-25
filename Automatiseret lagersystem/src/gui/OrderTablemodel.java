package gui;

import java.util.ArrayList;
import java.util.List;

import javax.swing.table.AbstractTableModel;

import model.Order;

	public class OrderTablemodel extends AbstractTableModel {
	private static final long serialVersionUID = 1L;
	private List<Order> data;
	private static final String[] COL_NAMES = {"OrderID", "State", "SentDate", "productID", "storeID" };
	
	public OrderTablemodel() {
		setData(null);
	}

	public OrderTablemodel(List<Order> data) {
		setData(data);
	}

	@Override
	public int getColumnCount() {
		return COL_NAMES.length;
	}

	@Override
	public String getColumnName(int column) {
		return COL_NAMES[column];
	}

	public void setData(List<Order> data) {
		if (data != null) {
			this.data = data;
		} else {
			this.data = new ArrayList<>(0);
			
			
		}
		super.fireTableDataChanged();
	}

	public Order getEmployeeOfRow(int index) {
		if (index < 0 || index >= data.size()) {
			return null;
		}
		return this.data.get(index);
	}

	@Override
	public Object getValueAt(int row, int column) {
		Order e = data.get(row);
		switch (column) {
		case 0:
			return e.getOrderId();
		case 1:
			return e.getState();
		case 2:
			return e.getSentDate();
		case 3:
			return e.getProduct().getProductId();
		case 4:
			return e.getStore().getstoreId();
		default:
			return "UNKNOLWN COL NAME";
		}
	}

	@Override
	public int getRowCount() {
		return data.size();
	}
	
}