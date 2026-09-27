package interfaces;
import java.lang.*;
import classes.IPackage;

public interface IPackageOperations
{
	boolean insertIPackage(IPackage p);
	boolean removeIPackage(IPackage p);
	IPackage searchIPackage(String iPackageNumber);
	void showAllIPackages();
}