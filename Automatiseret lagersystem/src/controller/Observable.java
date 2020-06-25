package controller;

public interface Observable {
	    public void notifyObservers(int productID, int storeId);
	    public void addObserver(Observer obs);
	    public void removeObser(Observer obs);
	}

