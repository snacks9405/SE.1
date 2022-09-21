using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace SE._1;

public class UserInterface
{
    public static void MainDisplay()
    {
        Console.WriteLine("Menu\n====\n1. List Entries\n2. Add Entry");
        Console.WriteLine("3. Delete Entry\n4. Edit Entry\n5. Quit\nChoice: ");
        String entryNum = Console.ReadLine();
        int confirmedNum;
        if (int.TryParse(entryNum, out confirmedNum))
        {

            switch (confirmedNum)
            {
                case 1:
                    ListEntries();
                    break;
                case 2:
                    AddEntry();
                    break;
                case 3:
                    DeleteEntry();
                    break;
                case 4:
                    EditEntry();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    BadEntry(0);
                    break;
            }
        }
        else
        {
            BadEntry(0);
            MainDisplay();
        }

    }

    public static void BadEntry(int errorCode)
    {
        const String initialChoice = " option. Please try again :)\n";
        const String badClue = "ClueLength\n";
        const String badAnswer = "AnswerLength\n";
        const String badDifficulty = "Difficulty\n";
        const String badDate = "Date\n";
        const String badID = "EntryID\n";

        Console.Write("Invalid ");
        switch (errorCode)
        {
            case 0: 
                Console.WriteLine(initialChoice);
                break;
            case 1:
                Console.Write(badClue);
                break;
            case 2:
                Console.Write(badAnswer);
                break;
            case 3:
                Console.Write(badDifficulty);
                break;
            case 4:
                Console.Write(badDate);
                break;
            case 5:
                Console.Write(badID);
                break;
            default:
                Console.Write("your guess is as good as mine!!\n");
                break;
        }
        MainDisplay();
    }
    public static void ListEntries()
    {
        Console.WriteLine("Entries\n-------\n{0}", BusinessLogic.GetList());
        MainDisplay();
    }
    public static void AddEntry()
    {
        ArrayList entry = new ArrayList();
        entry.Add(FlatDatabase.GetNextAvailableID());
        String[] addEntryPrompts = { "Clue: ", "Answer: ", "Difficulty: ", "Date: " };
        Console.WriteLine("Adding Entry\n==============");
        for (int i = 0; i < addEntryPrompts.Length; i++)
        {
            Console.Write(addEntryPrompts[i]);
            entry.Add(Console.ReadLine());
        }

        if(BusinessLogic.AddEntry(entry))
        {
            Console.WriteLine("Entry added successfuly!");
        } else
        {
            Console.WriteLine("Failed to write entry!");
        }
        MainDisplay();
    }

    public static void DeleteEntry()
    {
        Console.Write("Id to delete: ");
        BusinessLogic.RemoveEntry(Console.ReadLine());
        MainDisplay();
    }

    public static void EditEntry()
    {
        Console.WriteLine("edited entry");
        MainDisplay();
    }






}
