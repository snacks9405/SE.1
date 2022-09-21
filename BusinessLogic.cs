using System;
using System.Collections;
namespace SE._1
{
    public static class BusinessLogic
    {
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
        public static bool AddEntry(ArrayList entryArrList)
        {
            if (CheckEntry(entryArrList))
            {
                String entryString = "";
                for (int i = 1; i < entryArrList.Count; i++)
                {
                    entryString += entryArrList[i] + ", ";
                    if (i == entryArrList.Count - 1)
                    {
                        entryString += entryArrList[i];
                    }
                }

                if(FlatDatabase.AddEntry(entryString, int.Parse(entryArrList[0].ToString())))
                {
                    FlatDatabase.CommitChanges();
                    return true;

                } else
                {
                    return false;
                }
                
            }
            else
            {
                return false;
            }
        }

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
        public static bool CheckEntry(ArrayList entry)
        {
            return (entry != null);
        }


    }
}

