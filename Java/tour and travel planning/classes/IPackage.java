package classes;

import java.lang.*;
import interfaces.IPackageTransactions;

public abstract class IPackage implements IPackageTransactions
{	
	private String iPackageNumber;
	private double amountOfDay;
	private Tourist tourist;
	private double amount;
	
	public IPackage(){ }
	public IPackage(String iPackageNumber, Tourist tourist, double amountOfDay)
	{
		this.iPackageNumber = iPackageNumber;
		this.tourist = tourist;
		this.amountOfDay = amountOfDay;
	}
	
	public void setIPackageNumber(String iPackageNumber)
	{ 
		this.iPackageNumber = iPackageNumber;
	}
	public void setTourist(Tourist tourist)
	{	
		this.tourist = tourist;
	}
	public void setAmountOfDay(double amountOfDay)
	{	
		this.amountOfDay = amountOfDay;
	}
	

	public String getIPackageNumber()
	{	
		return iPackageNumber;
	}
	public Tourist getTourist()
	{	
		return tourist;
	}
	public double getAmountOfDay()
	{	
		return amountOfDay;
	}
	
	public abstract void showDetails();
	
	public boolean addDay(double amount)
	{
		if(amount>0)
		{
			this.amount=amount;
			amountOfDay = amountOfDay + amount;
			return true;
		}
		return false;
	}
	public boolean cancelDay(double amount)
	{
		if(amount>0 && amount<= amountOfDay)
		{
			this.amount=amount;
			amountOfDay = amountOfDay - amount;
			return true;
		}
		return false;
	}
}




