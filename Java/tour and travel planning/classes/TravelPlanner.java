package classes;

import java.lang.*;
import interfaces.*;

public class TravelPlanner implements IPackageOperations, TravelCounsellorOperations, TouristOperations
{
	private String name;
	private String locationName;
	IPackage ipackages[] = new IPackage [1000];
	Tourist tourists[] = new Tourist [500];
	TravelCounsellor travelCounsellors[] = new TravelCounsellor [100];
	
	public TravelPlanner(){}
	public TravelPlanner(String name, String locationName)
	{
		this.name = name;
		this.locationName = locationName;
	}
	
	public void setName(String name)
	{
		this.name = name;
	}
	public void setlocationName(String locationName)
	{
		this.locationName = locationName;
	}
	

	public String getName()
	{
		return name;
	}
	public String getlocationName()
	{
		return locationName;
	}

	public boolean insertIPackage(IPackage p)
	{
		for(int i=0; i<ipackages.length; i++)
		{
			if(ipackages[i] == null)
			{
				ipackages[i] = p;
				return true;
			}
		}
		return false;
	}
	
	public boolean removeIPackage(IPackage p)
	{
		for(int i=0; i<ipackages.length; i++)
		{
			if(ipackages[i] == p)
			{
				ipackages[i] = null;
				return true;
			}
		}
		return false;
	}
	
	public IPackage searchIPackage(String iPackageNumber)
	{
		for(int i=0; i<ipackages.length; i++)
		{
			if(ipackages[i] != null)
			{
				if(ipackages[i].getIPackageNumber().equals(iPackageNumber))
				{
					return ipackages[i];
				}
			}
		}
		return null;
	}
	
	public void showAllIPackages()
	{
		for(int i=0; i<ipackages.length; i++)
		{
			if(ipackages[i] != null)
			{
				ipackages[i].showDetails();
			}
		}
	}
	
	
	public boolean insertTourist(Tourist t)
	{
		for(int i=0; i<tourists.length; i++)
		{
			if(tourists[i] == null)
			{
				tourists[i] = t;
				return true;
			}
		}
		return false;
	}
	
	public boolean removeTourist(Tourist t)
	{
		for(int i=0; i<tourists.length; i++)
		{
			if(tourists[i] == t)
			{
				tourists[i] = null;
				return true;
			}
		}
		return false;
	}
	
	public Tourist searchTourist(int nid)
	{
		for(int i=0; i<tourists.length; i++)
		{
			if(tourists[i] != null)
			{
				if(tourists[i].getNid() == nid)
				{
					return tourists[i];
				}
			}
		}
		return null;
	}
	
	public void showAllTourists()
	{
		for(int i=0; i<tourists.length; i++)
		{
			if(tourists[i] != null)
			{
				tourists[i].showDetails();
			}
		}
	}
	
	public boolean insertTravelCounsellor(TravelCounsellor tc)
	{
		for(int i=0; i<travelCounsellors.length; i++)
		{
			if(travelCounsellors[i] == null)
			{
				travelCounsellors[i] = tc;
				return true;
			}
		}
		return false;
	}
	
	public boolean removeTravelCounsellor(TravelCounsellor tc)
	{
		for(int i=0; i<travelCounsellors.length; i++)
		{
			if(travelCounsellors[i] == tc)
			{
				travelCounsellors[i] = null;
				return true;
			}
		}
		return false;
	}
	
	public TravelCounsellor searchTravelCounsellor(String travelCounsellorId)
	{
		for(int i=0; i<travelCounsellors.length; i++)
		{
			if(travelCounsellors[i] != null)
			{
				if(travelCounsellors[i].getTravelCounsellorId().equals(travelCounsellorId))
				{
					return travelCounsellors[i];
				}
			}
		}
		return null;
	}
	
	public void showAllTravelCounsellors()
	{
		for(int i=0; i<travelCounsellors.length; i++)
		{
			if(travelCounsellors[i] != null)
			{
				travelCounsellors[i].showDetails();
			}
		}
	}
	
	public void showDetails()
	{
		System.out.println();
		System.out.println("\t\tTravel Planner Name     : " + name);
		System.out.println("\t\tTravel Planner Location : " + locationName);
		System.out.println();
		System.out.println("\t\t\t*** List of Package ***");
		System.out.println();
		this.showAllIPackages();		
		System.out.println();
		System.out.println("\t\t\t*** List of Travel Counsellor ***");
		System.out.println();
		this.showAllTravelCounsellors();
		
		
	}	
}

