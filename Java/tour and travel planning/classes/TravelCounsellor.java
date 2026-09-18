package classes;
import java.lang.*;

public class TravelCounsellor
{
	private String travelCounsellorId;
	private String name;
	private double salary;
	
	public void setTravelCounsellorId(String travelCounsellorId)
	{
		this.travelCounsellorId = travelCounsellorId;
	}
	public void setName(String name)
	{
		this.name = name;
	}
	public void setSalary(double salary)
	{
		this.salary = salary;
	}
	

	public String getTravelCounsellorId()
	{
		return travelCounsellorId;
	} 
	public String getName()
	{
		return name;
	}
	public double getSalary()
	{
		return salary;
	} 
	
	public void showDetails()
	{
		System.out.println("\t\t *** Travel Counsellor Information ***");
		System.out.println();
		System.out.println("\t\tTravel Counsellor ID     : " + travelCounsellorId);
		System.out.println("\t\tTravel Counsellor Name   : " + name);
		System.out.println("\t\tTravel Counsellor Salary : " + salary);
		System.out.println();
	}
}