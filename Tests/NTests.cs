using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using NUnit.Framework;
using Common;
using Newtonsoft.Json;

namespace Tests
{
    public class Tests
    {
        [Test]
        public async Task TestApi()
        {
            
                var json = JsonConvert.SerializeObject("123423,  г.Москва, ул. Народного ополчения, дом 3, кв. 364");
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                var url = "http://localhost:64558/api/values";
                var client = new HttpClient();

                var response = await client.PostAsync(url, data);

                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);

        }
    }
}