using System.Collections.Generic;
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
            var lines = File.ReadAllLines("good.csv");

            var data = new List<FullData>();

            foreach (var line in lines)
            {
                var arr = line.Split(';');

                var record = new FullData()
                {
                    id = long.Parse(arr[0]),
                    address = arr[1],
                    level = arr[2],
                    country = arr[3],
                    region = arr[4],
                    city = arr[5],
                    settlement = arr[6],
                    districtType = arr[7],
                    districtName = arr[8],
                    streetSocr = arr[9],
                    streetName = arr[10],
                    houseNumber = arr[11],
                    houseStructure = arr[12],
                    houseBody = arr[13],
                    flat = arr[14],
                    office = arr[15],
                };
                data.Add(record);

            }

            var a = 1;
        }
    }
}