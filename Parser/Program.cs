using System;
using System.Globalization;
using System.IO;
using Common;
using CsvHelper;

namespace Parser
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("bad.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.BadDataFound = null; //?
                while (csv.Read())
                {
                    var input = csv.GetRecord<FullData>();
                    
                }
                
            }
        }

    }
}
