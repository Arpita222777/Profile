package classes;

import java.lang.*;

public class PremiumPackage extends IPackage
{
	private String resortType;
	
	public PremiumPackage(){}
	public PremiumPackage(String iPackageNumber, Tourist tourist, double amountOfDay, String resortType)
	{
		super(iPackageNumber, tourist, amountOfDay);
		this.resortType = resortType;
	}
	
	public void setResortType(String resortType)
	{
		this.resortType = resortType;
	}
	public String getResortType()
	{
		return resortType;
	}
	
	public void showDetails()
	{   
		System.out.println();
		System.out.println("\t\t\t**** Premium Package Information ****");
		System.out.println();
		this.getTourist().showDetails();
		System.out.println("\t\tPackage Number        : " + this.getIPackageNumber());
		System.out.println("\t\tPackage Amount Of Day : " + this.getAmountOfDay());
		System.out.println("\t\tResort Type           : " + resortType);
		System.out.println();
	}
}