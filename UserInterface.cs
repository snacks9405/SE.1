using System.Collections;
namespace SE._1;

public class UserInterface
{
    readonly static String badEntry = "Invalid option. Please try again :)\n";

    public static void display()
    {
        Console.WriteLine("Menu\n====\n1. List Entries\n2. Add Entry");
        Console.WriteLine("3. Delete Entry\n4. Edit Entry\n5. Quit\nChoice: ");
        String entryNum = Console.ReadLine();
        int confirmedNum;
        if (Int32.TryParse(entryNum, out confirmedNum))
        {
        
            switch (confirmedNum)
            {
                case 1:
                    listEntries();
                    break;
                case 2:
                    addEntry();
                    break;
                case 3:
                    deleteEntry();
                    break;
                case 4:
                    editEntry();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine(badEntry);
                    display();
                    break;
            }
        }
        else
        {
            Console.WriteLine(badEntry);
            display();
        }

    }

    public static void listEntries()
    {
        Console.WriteLine("listed entries");

        display();
    }

    public static void addEntry()
    {
        ArrayList entry = new ArrayList();
        Console.WriteLine("added entry");

        display();
        //BusinessLogic.addEntry(entry);
    }

    public static void deleteEntry()
    {
        Console.WriteLine("deleted entry");

        display();
    }

    public static void editEntry()
    {
        Console.WriteLine("edited entry");
        display();
    }






}
