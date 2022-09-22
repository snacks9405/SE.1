using System.Text.Json;

namespace SE._1

{
    public static class FlatDatabase
    {
        const String fileName = "cwData.txt";
        public static SortedDictionary<int, String> data;
        static JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };

        public static void InitializeDB()
        {


            if (File.Exists(fileName))
            {
                String jsonString = File.ReadAllText(fileName);
                if (jsonString != "")
                {
                    data = JsonSerializer.Deserialize<SortedDictionary<int, String>>(jsonString);
                }
                else
                {
                    data = new SortedDictionary<int, String>();
                }
            }
            else
            {
                data = new SortedDictionary<int, String>();
            }
        }

        public static int GetNextAvailableID()
        {
            List<int> keys = new(data.Keys);
            for (int i = 1; i <= keys.Count; i++)
            {
                if (i < keys[i-1])
                {
                    return i;
                }
            }
            return (keys.Count == 0 ? 1 : keys.Count + 1);

        }
        public static bool AddEntry(String entryString, int entryNum)
        {
            return(data.TryAdd(entryNum, entryString));
        }

        public static void CommitChanges()
        {
            File.WriteAllText(fileName, JsonSerializer.Serialize(data, options));
        }

        public static bool RemoveEntry(int entryNumber)
        {
            return data.Remove(entryNumber);
        }


    }
}

