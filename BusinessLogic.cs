using System.Collections;
namespace SE._1
{
    public static class BusinessLogic
    {
        /// <summary>
        /// generates a string of entries to print to console.
        /// </summary>
        /// <returns>string of entries to print to console.</returns>
        public static String GetList()
        {
            String entriesString = "";
            if (FlatDatabase.data.Count > 0)
            {
                foreach (KeyValuePair<int, String> keyValPair in FlatDatabase.data)
                {
                    entriesString += keyValPair.Key + ". " + keyValPair.Value + "\n";
                }
            }
            return entriesString;
        }

        /// <summary>
        /// takes entry information from front end to create a new entry.
        /// </summary>
        /// <param name="entryArrList"></param>
        /// <returns></returns>
        public static bool AddEntry(ArrayList entryArrList)
        {
            if (CheckEntry(entryArrList))
            {
                String entryString = "";
                for (int i = 1; i < entryArrList.Count; i++)
                {

                    if (i == entryArrList.Count - 1)
                    {
                        entryString += entryArrList[i];
                        break;
                    }
                    entryString += entryArrList[i] + ", ";
                }

                if (FlatDatabase.AddEntry(entryString, int.Parse(entryArrList[0].ToString())))
                {
                    FlatDatabase.CommitChanges();
                    return true;

                }
            }
            return false;
        }

        /// <summary>
        /// takes entryID from front end to delete an entry
        /// </summary>
        /// <param name="idSelect"></param>
        public static void RemoveEntry(String idSelect)
        {
            if (int.TryParse(idSelect, out int idSelectInt))
            {
                if (!FlatDatabase.RemoveEntry(idSelectInt))
                {
                    Console.WriteLine("Failed to Delete Entry");
                    UserInterface.BadEntry(5);
                }
                else
                {
                    Console.WriteLine("Successfuly deleted entry #{0}\n", idSelect);
                    FlatDatabase.CommitChanges();
                }

            }
            else
            {
                UserInterface.BadEntry(5);
            }
        }

        /// <summary>
        /// verifies the entry number submitted matches an actual entry
        /// </summary>
        /// <param name="entryNumString"></param>
        /// <returns></returns>
        public static bool EntryExists(String entryNumString)
        {
            int entryID;
            if (int.TryParse(entryNumString, out entryID))
            {
                if (FlatDatabase.data.ContainsKey(entryID))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// verifies integrity of data fields. 
        /// 
        /// not clean or fun to look at or fun to write. this is the weakest part of the code.
        /// </summary>
        /// <param name="entry">an array of fields in the order: clue, answer, difficulty, date</param>
        /// <returns></returns>
        public static bool CheckEntry(ArrayList entry)
        {
            if (entry[1] != null)
            {
                String clue = entry[0].ToString();
                if (clue.Length > 200 || clue.Length == 0)
                {
                    UserInterface.BadEntry(1);
                    return false;
                }
            }
            if (entry[2] != null)
            {
                String answer = entry[1].ToString();
                if (answer.Length > 25 || answer.Length == 0)
                {
                    UserInterface.BadEntry(2);
                    return false;
                }
            }
            if (entry[3] != null)
            {
                String diffString = entry[3].ToString();
                int difficulty;
                if (int.TryParse(diffString, out difficulty))
                {
                    if (difficulty < 1 || difficulty > 3)
                    {
                        UserInterface.BadEntry(3);
                        return false;
                    }
                }
            }
            if (entry[4] != null)
            {
                bool goodDate = true;
                String date = entry[4].ToString();

                if (date.Length != 10)
                {
                    goodDate = false;
                }
                if (date[2] != '/' || date[5] != '/')
                {
                    goodDate = false;
                }
                int day;
                int month;
                int year;
                if (!int.TryParse(date.Substring(0, 2), out month))
                {
                    goodDate = false;
                }
                if (!int.TryParse(date.Substring(3, 2), out day))
                {
                    goodDate = false;
                }
                if (!int.TryParse(date.Substring(6, 4), out year))
                {
                    goodDate = false;
                }
                if (day > 31 || day < 0 || month < 0 || month > 12 || year > 2022)
                {
                    goodDate = false;
                }
                if (goodDate)
                {
                    return true;
                }
                UserInterface.BadEntry(4);
            }
            return false;
        }


    }
}

