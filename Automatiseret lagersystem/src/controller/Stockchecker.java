package controller;

import controller.Observer;
import controller.OrderController;
import controller.StoreController;
import model.Order;
import model.Stock;
import model.Store;
import controller.StockController;
import java.util.ArrayList;
import java.util.Collection;
import java.util.List;

public class Stockchecker implements Runnable, Observable  {

	private OrderController octr;
	private Observer oCTR;
	private StoreController Sctr;
	private StockController stockctr;
	private Collection<Observer> observers;
	
	public Stockchecker() {
		try {
			oCTR = new OrderController();
			octr = new OrderController();
			Sctr = new StoreController();
			stockctr = new StockController();
			this.observers = new ArrayList<>();
		} catch (DataAccessException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		addObserver(octr);
		
	}
	
	/* This adds an observer, which checks on Stock */
	@Override
	public void addObserver(Observer obs) {
		// TODO Auto-generated method stub
		observers.add(obs);
	}

	/* This removes an observer from a stock */
	@Override
	public void removeObser(Observer obs) {
		// TODO Auto-generated method stub
		observers.remove(obs);
	}

	/* Initiates the observer */
	@Override
	public void run() {
//		 TODO Auto-generated method stub
		while(true) {
		try {
			ArrayList<Store> stores = (ArrayList<Store>) Sctr.findallstoreswtihstocks();
			if (stores !=null) {
				Integer amout = null;
				Integer currminamout = null;
				Integer currStoreid =	null;
				Integer currproductid = null;
				int i = 0;
				boolean noOrderfound = true;
				while (stores.size() > i) {
					int i2 =0;
					while (stores.get(i).getStocks().size() > i2) {
						amout = stores.get(i).getStocks().get(i2).getAmount();
						currminamout = stores.get(i).getStocks().get(i2).getSupplyMinAmount();
						if (amout <= currminamout) {
							currStoreid = stores.get(i).getstoreId();
							currproductid = stores .get(i).getStocks().get(i2).getProduct().getProductId();
							ArrayList<Order> Orders = (ArrayList<Order>) octr.findByProductIDStoreID(currStoreid, currproductid);
							int i3 = 0;
							while (i3 < Orders.size()) {
								if(Orders.get(i3).getState() != null && Orders.get(i3).getState() != "Done") {
									noOrderfound = false;
								}
								i3++;
							}
							if (noOrderfound ==true) {
								notifyObservers(currproductid, currStoreid);;
							}
						}
						
					i2++;
					}
					
					i++;
				}
			} 
		} catch (DataAccessException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		}
	}

	/* This notifies observers */
	@Override
	public void notifyObservers(int productID, int storeId) {
		// TODO Auto-generated method stub
		for(Observer o : observers)
			o.notifyMe(productID, storeId);
	}




}