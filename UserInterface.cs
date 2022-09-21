using System.Collections;
namespace SE._1;

public class UserInterface
{
    public static void mainDisplay()
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
                    badEntry(0);
                    break;
            }
        }
        else
        {
            badEntry(0);
            mainDisplay();
        }

    }

    public static void badEntry(int errorCode)
    {
        const String initialChoice = " option. Please try again :)\n";
        const String badClue = "ClueLength";
        const String badAnswer = "AnswerLength";
        const String badDifficulty = "Difficulty";
        const String badDate = "Date";

        Console.WriteLine("Invalid" + (errorCode == 0 ? initialChoice : (errorCode == 1 ? badClue : (errorCode == 2 ? badAnswer : (errorCode == 3 ? badDifficulty : badDate)))));
        mainDisplay();
    }
    public static void listEntries()
    {
        Console.WriteLine("listed entries");
        foreach (KeyValuePair<int, String> keyValPair in FlatDatabase.data)
        {
            Console.Write("{0}. {1}", keyValPair.Key, keyValPair.Value); 
        }
        mainDisplay();
    }
    public static void addEntry()
    {
        ArrayList entry = new ArrayList();
        entry.Add(9);
        entry.Add("poopy");
        entry.Add("soupy");
        //Console.WriteLine("added entry");


        BusinessLogic.addEntry(entry);
        mainDisplay();
    }

    public static void deleteEntry()
    {
        Console.WriteLine("deleted entry");

        mainDisplay();
    }

    public static void editEntry()
    {
        Console.WriteLine("edited entry");
        mainDisplay();
    }






}
