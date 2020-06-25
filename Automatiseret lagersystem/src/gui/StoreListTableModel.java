package gui;

import java.util.ArrayList;
import java.util.List;

import javax.swing.table.AbstractTableModel;

import model.Store;

	public class StoreListTableModel extends AbstractTableModel {
	private static final long serialVersionUID = 1L;
	private List<Store> data;
	private static final String[] COL_NAMES = {"storeID", "Address", "Zip","City", "Priotycaroty" };

	public StoreListTableModel() {
		setData(null);
	}

	public StoreListTableModel(List<Store> data) {
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

	public void setData(List<Store> data) {
		if (data != null) {
			this.data = data;
		} else {
			this.data = new ArrayList<>(0);
			Store store = new Store();
			store.setAddress("test");
			store.setPriorityCategory("a");
			store.setZip("1212");
			this.data.add(store);
			
		}
		super.fireTableDataChanged();
	}

	public Store getEmployeeOfRow(int index) {
		if (index < 0 || index >= data.size()) {
			return null;
		}
		return this.data.get(index);
	}

	@Override
	public Object getValueAt(int row, int column) {
		Store e = data.get(row);
		switch (column) {
		case 0:
			return e.getstoreId();
		case 1:
			return e.getAddress();
		case 2:
			return e.getZip();
		case 3:
			return e.getCity();
		case 4:
			return e.getPriorityCategory();
		default:
			return "UNKNOLWN COL NAME";
		}
	}

	@Override
	public int getRowCount() {
		return data.size();
	}
	
}