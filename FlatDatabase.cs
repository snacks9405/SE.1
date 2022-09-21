using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.Json;

namespace SE._1

{
    public static class FlatDatabase
    {
        const String fileName = "cwData.txt";
        public static SortedDictionary<int, String> data;
        static JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        //int id = 1;
        //string clue;
        //string answer;
        //int difficulty;
        //string date;

        //string[] entry = new string[5];

        public static void initializeDB()
        {


            if (File.Exists(fileName))
            {
                String jsonString = File.ReadAllText(fileName);
                if (jsonString != null)
                {
                    data = JsonSerializer.Deserialize<SortedDictionary<int, String>>(jsonString);
                }
                Console.WriteLine(data);
            }
            else
            {
                data = new SortedDictionary<int, String>();
            }
        }

        public static void addEntry(String entryString, int entryNum)
        {
            data.Add(entryNum, entryString);

            File.WriteAllText(fileName, JsonSerializer.Serialize(data, options));
        }


    }
}

