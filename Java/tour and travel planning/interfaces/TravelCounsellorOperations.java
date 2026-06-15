package interfaces;
import java.lang.*;
import classes.TravelCounsellor;

public interface TravelCounsellorOperations
{
	boolean insertTravelCounsellor(TravelCounsellor tc);
	boolean removeTravelCounsellor(TravelCounsellor tc);
	TravelCounsellor searchTravelCounsellor(String travelCounsellorId);
	void showAllTravelCounsellors();
}