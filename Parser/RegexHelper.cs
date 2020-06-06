using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Parser
{
    public class RegexData
    {
        public string RegexFormat { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
    }
    public static class RegexHelper
    {
        public static RegexData[] RegexData;

        static RegexHelper()
        {
            var lines = File.ReadAllLines("regex.csv");
            RegexData = new RegexData[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                var spl = lines[i].Split('\t');
                RegexData[i] = new RegexData(){ RegexFormat = spl[0], OldValue = spl[1], NewValue = spl[2]}; 
            }
        }
    }
}
