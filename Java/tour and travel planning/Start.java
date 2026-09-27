import java.lang.*;
import classes.*;
import java.util.Scanner;
import fileio.FileReadWriteDemo;
 
 public class Start 
 {
 	public static void main(String args[])
 	{
 		Scanner sc = new Scanner(System.in);
		FileReadWriteDemo frwd = new FileReadWriteDemo();
		String n, bn;
		System.out.println();		
		System.out.print("\t\t Enter Travel Planner Name  : ");		
		n = sc.next();
		System.out.print("\t\t Enter Location Name        : ");		
		bn = sc.next();
		TravelPlanner b = new TravelPlanner(n, bn);
		
		System.out.println();
		System.out.println("\t\t\t|-----------------------------------------------------------|");
		System.out.println("\t\t\t       Welcome to "+b.getName()+" Travel Planner           ");
		System.out.println("\t\t\t|-----------------------------------------------------------|");
		
		boolean repeat = true;
		
		while(repeat)
		{
			System.out.println();
			System.out.println("\tWhat Do You Want To Do?\n");
			System.out.println("\t\t--------------------------------------------");
			System.out.println("\t\t|Enter-1.  Travel Counsellor Management    |");
			System.out.println("\t\t|Enter-2.  Tourist Management              |");
			System.out.println("\t\t|Enter-3.  Package Management              |");
			System.out.println("\t\t|Enter-4.  Package Transactions            |");
			System.out.println("\t\t|Enter-5.  Show Travel Planner Information |");
			System.out.println("\t\t|Enter-6.  Exit                            |");				
			System.out.println("\t\t--------------------------------------------");
			System.out.print("  \t\tEnter Your Choice: ");
			int choice = sc.nextInt();
				
 


			switch(choice)
			{
				case 1:
					System.out.println();
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t | You Have Selected Travel Counsellor Management |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();
					
					boolean repeat1 = true;

					while(repeat1)
					{
					    System.out.println();
						System.out.println("\t\tTravelCounsellor Management Options are: \n");
						System.out.println("\t\t----------------------------------------------");
						System.out.println("\t\t|Enter-1. Insert New Travel Counsellor       |");
						System.out.println("\t\t|Enter-2. Remove Travel Counsellor           |");
						System.out.println("\t\t|Enter-3. Search Travel Counsellor           |");
						System.out.println("\t\t|Enter-4. Show All Travel Counsellors        |");
						System.out.println("\t\t|Enter-5. Go Back                            |");					
						System.out.println("\t\t----------------------------------------------");
						System.out.print("  \t\tEnter Your Option: ");
						int option1 = sc.nextInt();
						
						

						switch(option1)
						{
							case 1:
					         System.out.println();
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println("\t\t |   You Have Selected Insert Travel Counsellor   |");
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println();
								
								System.out.print("\t\tEnter Travel Counsellor ID: ");
								String travelCounsellorId1 = sc.next();
								System.out.print("\t\tEnter Travel Counsellor Name: ");
								String name1 = sc.next();
								System.out.print("\t\tEnter Salary: ");
								double salary1 = sc.nextDouble();
								
								TravelCounsellor tc1 = new TravelCounsellor();
								tc1.setTravelCounsellorId(travelCounsellorId1);
								tc1.setName(name1);
								tc1.setSalary(salary1);
								System.out.println();
								
								if(b.insertTravelCounsellor(tc1))
								{
									System.out.println("\t\t---->"+travelCounsellorId1 + " Travel Counsellor Has Been Inserted");
								}
								else
								{
									System.out.println("\t\t---->"+travelCounsellorId1 + " Travel Counsellor Can NOT be Inserted");
								}
								
								
								break;

					
					        case 2:
					         System.out.println();			
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println("\t\t |   You Have Selected Remove Travel Counsellor   |");
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println();
								
								System.out.print("\tEnter The Travel Counsellor Id to remove a Travel Consellor:\n ");
								String travelCounsellorId2 = sc.next();
								
								TravelCounsellor tc2 = b.searchTravelCounsellor(travelCounsellorId2);
								
								if(tc2 != null)
								{
									if(b.removeTravelCounsellor(tc2))
									{
										System.out.println("\t\t*** Travel Counsellor Removed ***");
									}
								}
								else
								{
									System.out.println("\t\t*** Travel Counsellor Can NOT be Removed ***");
								}
								
								break;
							case 3:
					         System.out.println();		
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println("\t\t |   You Have Selected Search Travel Counsellor   |");
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println();			
								
								System.out.print("\t\tEnter The Travel Counsellor Id to search a Travel Counsellor:\n ");
								String travelCounsellorId3 = sc.next();
								
								TravelCounsellor tc3 = b.searchTravelCounsellor(travelCounsellorId3);
								
								if(tc3 != null)
								{
									System.out.println("\t\t*** Travel Counsellor Found ***");
									tc3.showDetails();
								}
								else
								{
									System.out.println("\t\t*** Travel Counsellor NOT Found ***");
								}
								
								break;	


								case 4:
					             System.out.println();			
					             System.out.println("\t\t |------------------------------------------------|");
					             System.out.println("\t\t |  You Have Selected Show All Travel Counsellors |");
					             System.out.println("\t\t |------------------------------------------------|");
					             System.out.println();			
								
								b.showAllTravelCounsellors();
								
								break;
								
							case 5:
								System.out.println();
								System.out.println("\t\t|-----------------------|");
								System.out.println("\t\t|     Going Back....    |");
								System.out.println("\t\t|-----------------------|");
								repeat1 = false;
								System.out.println();
								break;
								
							default:
								System.out.println();
								System.out.println("\t\t|--------------------------|");
								System.out.println("\t\t|     Select Again!......  |");
								System.out.println("\t\t|--------------------------|");
								System.out.println();
								
								break;
						}
					}
					
					break;


					case 2:
					System.out.println();
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t |     You Have Selected Tourist Management       |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();	
					
					boolean repeat2 = true;
					
					while(repeat2)
					{
					    System.out.println();
						System.out.println("\tTourist Management Options are: \n");
						System.out.println("\t\t----------------------------------------------");
						System.out.println("\t\t|Enter-1. Insert New Tourist                 |");
						System.out.println("\t\t|Enter-2. Remove Tourist                     |");
						System.out.println("\t\t|Enter-3. Search Tourist                     |");
						System.out.println("\t\t|Enter-4. Show All Tourists                  |");
						System.out.println("\t\t|Enter-5. Go Back                            |");
						System.out.println("\t\t----------------------------------------------");
						
						
						System.out.print("\t\tEnter Your Option: ");
						int option2 = sc.nextInt();
						



						switch(option2)
						{
							case 1:
					         System.out.println();		
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println("\t\t |        You Have Selected Insert Tourist        |");
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println();	
								
								System.out.print("\t\tEnter Tourist NID  : ");
								int nid1 = sc.nextInt();
								System.out.print("\t\tEnter Tourist Name : ");
								String name1 = sc.next();
								System.out.print("\t\tEnter Phone Number : ");
								String phnNumber1 = sc.next();
								
								Tourist c1 = new Tourist();
								c1.setNid(nid1);
								c1.setName(name1);
								c1.setPhnNumber(phnNumber1);
								System.out.println();
								
								if(b.insertTourist(c1))
								{
									System.out.println("\t\t----->"+nid1 + " Tourist Has Been Inserted");
								}
								else
								{
									System.out.println("\t\t----->"+nid1 + " Tourist Can NOT be Inserted");
								}
							
								break;
								
							case 2:
					         System.out.println();			
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println("\t\t |       You Have Selected Remove Tourist         |");
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println();
								
								System.out.print("\t\tEnter The NID to remove a Tourist: ");
								int nid2 = sc.nextInt();
								
								Tourist c2 = b.searchTourist(nid2);
								
								if(c2 != null)
								{
									if(b.removeTourist(c2))
									{
										System.out.println("\t\t\t*** Tourist Removed ***");
									}
								}
								else
								{
									System.out.println("\t\t\t*** Tourist Can NOT be Removed ***");
								}
								
								break;
								
							case 3:
					         System.out.println();		
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println("\t\t |       You Have Selected Search Tourist         |");
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println();
								
								System.out.print("\t\tEnter The NID to search a Tourist: ");
								int nid3 = sc.nextInt();
								
								Tourist c3 = b.searchTourist(nid3);
								
								if(c3 != null)
								{
									System.out.println("\t\t\t*** Tourist Found ***");
									c3.showDetails();
								}
								else
								{
									System.out.println("\t\t\t*** Tourist NOT Found ***");
								}
								
								break;
								
							case 4:
					         System.out.println();			
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println("\t\t |       You Have Selected Show All Tourist       |");
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println();
								
								b.showAllTourists();
								
								break;
								
							case 5:
								System.out.println();
								System.out.println("\t\t|------------------------------------|");
								System.out.println("\t\t|           Going Back........       |");
								System.out.println("\t\t|------------------------------------|");
								repeat2 = false;
								System.out.println();
								break;
								
							default:
								System.out.println();
								System.out.println("\t\t|-----------------------------------|");
								System.out.println("\t\t|         Select Again!......       |");
								System.out.println("\t\t|-----------------------------------|");
								System.out.println();
								
								break;
						}
					}
					
					break;
					

					case 3:
				    System.out.println();
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t |      You Have Selected Package Management      |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();
					
					boolean repeat3 = true;
					
					while(repeat3)
					{
					    System.out.println();
						System.out.println("\tPackage Management Options are: \n    ");
						System.out.println("\t\t----------------------------------------------");
						System.out.println("\t\t|1. Insert New Package                       |");
						System.out.println("\t\t|2. Remove Package                           |");
						System.out.println("\t\t|3. Search Package                           |");
						System.out.println("\t\t|4. Show All Packages                        |");
						System.out.println("\t\t|5. Go Back                                  |");
						System.out.println("\t\t----------------------------------------------");			
						System.out.print("\t\tEnter Your Option: ");
						int option3 = sc.nextInt();
							
                   

                   switch(option3)
						{
							case 1:
					         System.out.println();			
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println("\t\t |        You Have Selected Insert Package        |");
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println();
								
								System.out.print("\t\tEnter Tourist NID for Verification: ");
								int nid1 = sc.nextInt();
								
								Tourist c1 = b.searchTourist(nid1);
								
								if(c1 != null)
								{
									System.out.println("\t\t\t**** Valid Tourist ****");
									System.out.println();
									System.out.println("\tWhich Type of Package do you want to create?");
									System.out.println("\t\t----------------------------------------------");
									System.out.println("\t\t|1. Normal Package                           |");
									System.out.println("\t\t|2. Premium Package                          |");
									System.out.println("\t\t|3. Go Back                                  |");						
									System.out.println("\t\t----------------------------------------------");
									System.out.print("\t\tEnter Your Type: ");
									int type = sc.nextInt();
										
									
									IPackage a = null;
									
									if(type == 1)
									{
					           System.out.println();					
					           System.out.println("\t\t |------------------------------------------------|");
					           System.out.println("\t\t |                  Normal Package                |");
					           System.out.println("\t\t |------------------------------------------------|");
					           System.out.println();
										
										System.out.print("\t\tEnter Package Number        : ");
										String an = sc.next();
										System.out.print("\t\tEnter Package Amount Of Day : ");
										double ba = sc.nextDouble();
										System.out.print("\t\tEnter Hotel Type            : ");
										String ir = sc.next();
										
										NormalPackage sa = new NormalPackage(an, c1, ba, ir);
										
										a = sa;
										
									}
									else if(type == 2)
									{
				                System.out.println();						
					            System.out.println("\t\t |------------------------------------------------|");
					            System.out.println("\t\t |               Premium Package                  |");
					            System.out.println("\t\t |------------------------------------------------|");
					            System.out.println();
										
										System.out.print("\t\tEnter Package Number         : ");
										String an = sc.next();
										System.out.print("\t\tEnter Package Amount Of Day  : ");
										double ba = sc.nextDouble();
										System.out.print("\t\tEnter Resort Type            : ");
										String ty = sc.next();
										
										PremiumPackage fa = new PremiumPackage(an, c1, ba, ty);
										
										a = fa;
									}
									else if(type == 3)
									{
					           System.out.println();						
					           System.out.println("\t\t |------------------------------------------------|");
					           System.out.println("\t\t |                  Going Back.....               |");
					           System.out.println("\t\t |------------------------------------------------|");
					            System.out.println();
									}
									else
									{
								System.out.println();		
								System.out.println("\t\t |------------------------------------------------|");
					            System.out.println("\t\t |               Invalid Type                     |");
					            System.out.println("\t\t |------------------------------------------------|");
					            System.out.println();
									}
									
									if(a != null)
									{
										if(b.insertIPackage(a))
										{
											System.out.println("\t\t\t*** Package Inserted ***");
										}
										else
										{
											System.out.println("\t\t\t*** Package NOT Inserted ***");
										}
									}
									
								}
								else
								{
									System.out.println("\t\t\t**** Invalid Tourist ****");
								}
								
								break;

                case 2:
								
					System.out.println();			
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t |       You Have Selected Remove Package         |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();
								
								
								System.out.print("\tEnter The Pacakge Number to remove a Package: \n");
								String iPackageNumber2 = sc.next();
								
								IPackage ip2 = b.searchIPackage(iPackageNumber2);
								
								if(ip2 != null)
								{
									if(b.removeIPackage(ip2))
									{
										System.out.println("\t\t\t*** Package Removed ***");
									}
								}
								else
								{
									System.out.println("\t\t\t*** Package Can NOT be Removed ***");
								}
								
								
								break;
                    
                    case 3:
                    System.out.println();
                    System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t |       You Have Selected Search Package         |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();
								
								System.out.print("Enter The Package Number to search a package: ");
								String iPackageNumber3 = sc.next();
								
								IPackage ip3 = b.searchIPackage(iPackageNumber3);
								
								if(ip3 != null)
								{
									System.out.println("\t\t\t*** Package Found ***");
									ip3.showDetails();
								}
								else
								{
									System.out.println("\t\t\t*** Package NOT Found ***");
								}
								
								break;
              
                  case 4:
					System.out.println();			
				    System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t |     You Have Selected Show All Packages        |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();
								
								b.showAllIPackages();
								
								break;
            
            case 5:
					System.out.println();						
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t |               Going Back.....                  |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();
								repeat3 = false;
								System.out.println();
								break;
								
							default:
								System.out.println();
								System.out.println("\t\t|-----------------------------------|");
								System.out.println("\t\t|         Select Again!......       |");
								System.out.println("\t\t|-----------------------------------|");
								System.out.println();
								
								break;
						}
					}
				
					break;
         

            case 4:
					System.out.println();
				    System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t |    You Have Selected Package Transactions      |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();
					
					boolean repeat4 = true;
					
					while(repeat4)
					{
					
						System.out.println("\tPackage Transaction Options are: \n");
						System.out.println("\t\t---------------------------------");
						System.out.println("\t\t|Enter-1. Add Day               |");
						System.out.println("\t\t|Enter-2. Cancel Day            |");
						System.out.println("\t\t|Enter-3. Go Back               |");
						System.out.println("\t\t---------------------------------");
						
						
						System.out.print("\t\tEnter Your Option: ");
						int option4 = sc.nextInt();
						
						
						switch(option4)
						{
							case 1:
					          System.out.println();		
					          System.out.println("\t\t |------------------------------------------------|");
					          System.out.println("\t\t |          You Have Selected Add Day             |");
					          System.out.println("\t\t |------------------------------------------------|");
					          System.out.println();
								
								System.out.print("\t\tEnter Package Number: ");
								String an1 = sc.next();
								
								IPackage a1 = b.searchIPackage(an1);
								
								if(a1 != null)
								{
									System.out.println("\t\t*** Valid Package ***");
									
									System.out.println("\t\tCurrent Total Day	:"+ a1.getAmountOfDay());
									System.out.println("\t\tAdd Day	            : ");
									double am = sc.nextDouble();
									if(a1.addDay(am))
									{
										System.out.println("\t\t**--- Add Day Successfull ---**");

										System.out.println(   "\t\tNew Total Day	:"+ a1.getAmountOfDay());
										frwd.writeInFile(am + "\t\t Add Day in      :"+ a1.getIPackageNumber());
									}
									else
									{
										System.out.println("\t\t\t**--- Add Day Failed ---**");
									}
								}
								
								break;

                  case 2:
					System.out.println();			
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t |         You Have Selected Cancel Day           |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();
								
								System.out.print("\t\tEnter Package Number: ");
								String an2 = sc.next();
								
								IPackage a2 = b.searchIPackage(an2);
								
								if(a2 != null)
								{
									System.out.println("\t\t\t*** Valid Package ***");
									System.out.println();
									System.out.println("\t\tCurrent Total Day	: "+ a2.getAmountOfDay());
									System.out.println("\t\tCancel Day	        : ");
									double am = sc.nextDouble();
									if(a2.cancelDay(am))
									{
										System.out.println("\t\t**--- Cancel Day Successfull ---**");
										System.out.println();
										System.out.println("   \t\tNew Total Day	 :"+ a2.getAmountOfDay());
										frwd.writeInFile(am + "\t\tCancel Day in     :"+ a2.getIPackageNumber());
									}
									else
									{
										System.out.println("\t\t**--- Cancel Day Failed ---**");
									}
								}
								
								break;
								
							case 3:
					         System.out.println();						
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println("\t\t |                  Going Back.....               |");
					         System.out.println("\t\t |------------------------------------------------|");
					         System.out.println();
								repeat4 = false;
								break;
								
							default:
								System.out.println();
								System.out.println("\t\t|-----------------------------------|");
								System.out.println("\t\t|           Select Again!......     |");
								System.out.println("\t\t|-----------------------------------|");
								System.out.println();
								
								break;
						}
					}
					
					break;
					
				case 5:
					System.out.println();
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t |  You Have Selected Travel Planner Information  |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();
					
					b.showDetails();
					
					break;
					
				case 6:
					System.out.println();
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println("\t\t |     Thank you for using our application....    |");
					System.out.println("\t\t |------------------------------------------------|");
					System.out.println();
					
					repeat = false;
					
					break;
					
				default:
				                System.out.println();
								System.out.println("\t\t|-----------------------------------|");
								System.out.println("\t\t|       Invalid Selection......     |");
								System.out.println("\t\t|-----------------------------------|");
								System.out.println();
					
					break;
			}
		}				
 	}
 }
 