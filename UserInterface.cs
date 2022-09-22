using System.Collections;
namespace SE._1
{
    public static class UserInterface
    {

        /// <summary>
        /// sends primary prompt to console
        /// </summary>
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

        /// <summary>
        /// responds to errorcode with appropriate message as outlined below
        /// </summary>
        /// <param name="errorCode"></param>
        public static void BadEntry(int errorCode)
        {
            //0 = bad initial choice
            //1 = bad clue length
            //2 = bad answer length
            //3 = bad difficulty
            //4 = bad date
            //5 = bad ID entry
            String[] errorArr = { " option. Please try again :)\n", "ClueLength\n", "AnswerLength\n", "Difficulty\n", "Date\n", "EntryID\n" };
            Console.WriteLine("Invalid " + errorArr[errorCode]);
        }

        /// <summary>
        /// lists all current entries to console
        /// </summary>
        public static void ListEntries()
        {
            Console.WriteLine("Entries\n-------\n{0}", BusinessLogic.GetList());
            MainDisplay();
        }

        /// <summary>
        /// prompts user for each field of entry
        /// </summary>
        public static void AddEntry()
        {
            ArrayList entry = new ArrayList();
            entry.Add(FlatDatabase.GetNextAvailableID());
            String[] addEntryPrompts = { "Clue: ", "Answer: ", "Difficulty: ", "Date (mm/dd/yyyy): " };
            Console.WriteLine("Adding Entry\n==============");
            for (int i = 0; i < addEntryPrompts.Length; i++)
            {
                Console.Write(addEntryPrompts[i]);
                entry.Add(Console.ReadLine());
            }

            if (BusinessLogic.AddEntry(entry))
            {
                Console.WriteLine("Entry added successfuly!\n");
            }
            else
            {
                Console.WriteLine("Failed to write entry!\n");
            }
            MainDisplay();
        }

        /// <summary>
        /// prompts user to enter ID of entry to delete
        /// </summary>
        public static void DeleteEntry()
        {
            Console.Write("Id to delete: ");
            BusinessLogic.RemoveEntry(Console.ReadLine());
            MainDisplay();
        }

        /// <summary>
        /// prompts user to enter ID of entry to modify
        /// </summary>
        public static void EditEntry()
        {
            Console.Write("Id to edit: ");
            String entryID = Console.ReadLine();
            if (BusinessLogic.EntryExists(entryID))
            {
                BusinessLogic.RemoveEntry(entryID);
                AddEntry();
                MainDisplay();
            } else
            {
                BadEntry(5);
            }
            
        }
    }

}