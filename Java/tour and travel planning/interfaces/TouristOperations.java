package interfaces;
import java.lang.*;
import classes.Tourist;

public interface TouristOperations
{
	boolean insertTourist(Tourist t);
	boolean removeTourist(Tourist t);
	Tourist searchTourist(int nid);
	void showAllTourists();

}