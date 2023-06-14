using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace landmark_realty
{
    public static class Class1
    {
        //CHECK IF DATABASE FILE EXISTS, IF NOT CREATE ONE
        public static int findHowManyRecords(string databaseLocation)
        {
            List<string> allLines = File.ReadAllLines(databaseLocation).ToList();
            return allLines.Count / 23;
        }
    }
}
