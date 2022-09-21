using System;
using System.Collections;
namespace SE._1
{
    public static class BusinessLogic
    {
        public static bool addEntry(ArrayList entryArrList)
        {
            if (checkEntry(entryArrList))
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
                
                FlatDatabase.addEntry(entryString, int.Parse(entryArrList[0].ToString()));
                return true;
            } else
            {
                return false;
            }
        }

        //public static String[] getList()
        //{

        //}
        public static bool checkEntry(ArrayList entry)
        {
            return (entry != null);
        }
    }
}

