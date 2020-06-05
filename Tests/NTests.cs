using System.Globalization;
using System.IO;
using CsvHelper;
using NUnit.Framework;
using Common;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void Test1()
        {
            using (var reader = new StreamReader("bad.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.MissingFieldFound = (strings, i, arg3) => { };
                csv.Configuration.BadDataFound = null; //?
                while (csv.Read())
                {
                    var input = csv.GetRecord<FullData>();

                }

            }
        }
    }
}