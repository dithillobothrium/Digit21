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

                using (var writer = new StreamWriter("../../../../result_digit21.csv"))
                {
                    writer.NewLine = "\n";
                    while (csv.Read())
                    {
                        var input = csv.GetRecord<Data>();
                        var parser = new AddressParser();
                        input.addressNew = parser.Process(input.address);
                        writer.WriteLine(input.id + ";" + input.address + ";" + input.addressNew);
                    }
                }
            }
        }

    }


}
