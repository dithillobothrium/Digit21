using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
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
            using (var reader = new StreamReader("good.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.HasHeaderRecord = true;
                csv.Configuration.Delimiter = ";";
                csv.Configuration.MissingFieldFound = null;
                csv.Configuration.BadDataFound = null; //?
                csv.Configuration.HeaderValidated = null;
                csv.Configuration.IgnoreQuotes = true;
                while (csv.Read())
                {
                    var anonymousTypeDefinition = new
                    {
                        Id = string.Empty,
                        address = string.Empty,
                        level = string.Empty,
                        country = string.Empty,
                        region = string.Empty,
                        city = string.Empty,
                        settlement = string.Empty,
                        districtType = string.Empty,
                        districtName = string.Empty,
                        street = string.Empty,
                        houseNumber = string.Empty,
                        houseStructure = string.Empty,
                        houseBody = string.Empty,
                        flat = string.Empty,
                        //office = string.Empty,
                    };
                    var input = csv.GetRecord(anonymousTypeDefinition);

                }

            }
        }

        [Test]
        public void Test2()
        {

        }
    }
}