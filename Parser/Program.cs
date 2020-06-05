using System;
using System.Globalization;
using System.IO;
using Common;
using CsvHelper;
using CsvHelper.Configuration;

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
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.IgnoreQuotes = true;
                //csv.Configuration
                while (csv.Read())
                {
                    var input = csv.GetRecord<FullData>();

                    var parser = new AddressParser();

                    var result = parser.Process(input); 
                }
                
            }
        }

    }


}
