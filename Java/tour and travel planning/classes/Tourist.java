package classes;
import java.lang.*;

public class Tourist
{
	private int nid;
	private String name;
	private String phnNumber;
	
	public void setNid(int nid)
	{
		this.nid = nid;
	}
	public void setName(String name)
	{
		this.name = name;
	}
	public void setPhnNumber(String phnNumber)
	{
		this.phnNumber = phnNumber;
	}
	

	public int getNid()
	{
		return nid;
	}
	public String getName()
	{
		return name;
	}
	public String getPhnNumber()
	{
		return phnNumber;
	}
	
	public void showDetails()
	{   
		System.out.println();
		System.out.println("\t\t*** Tourist Information ***");
		System.out.println();
		System.out.println("\t\tTourist NID          : " + nid);
		System.out.println("\t\tTourist Name         : " + name);
		System.out.println("\t\tTourist Phone Number : " + phnNumber);
		System.out.println();
	}
}