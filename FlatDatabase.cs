using System;
namespace SE._1

{
    public class FlatDatabase
    {
        public static List<String[]> compendium = new List<String[]>();

        int id = 1;
        string clue;
        string answer;
        int difficulty;
        string date;
        FileStream readWriteGuy;

        string[] entry = new string[5];

        public FlatDatabase()
        {
            readWriteGuy = new FileStream("compendium.txt", FileMode.OpenOrCreate,
            FileAccess.ReadWrite);
            foreach (String[] line in compendium)
            {
                foreach (String pieceOfLine in line)
                {
                    readWriteGuy.WriteAsync("Compendium.txt", pieceOfLine);
                    File.WriteAllText("Compendium.txt", pieceOfLine);
                    File.WriteAllText("Compendium.txt", ",");
                        }
                File.WriteAllText("compendium.txt","\n");
            }
        }

        public bool writeChanges()
        {

        }

        public static List<String[]> Get()
        {
            return compendium;
        }
    }
}

