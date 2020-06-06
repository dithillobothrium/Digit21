using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Common
{
    public class AddressParser
    {
        public string Process(string data)
        {
          
            // CLeanup
            return CleanupAddress(data);

        }

        private string CleanupAddress(string addr)
        {
            addr = addr.Replace("\"", ""); // remove quotes

            addr.TrimStart('(');

            //вычищаем с помощью регулярных выражений лишние данные
            RegexData[] regexFormatList = RegexHelper.RegexData;
            foreach (RegexData format in regexFormatList)
            {
                string pattern = format.RegexFormat;
                string oldValue = format.OldValue;
                string newValue = format.NewValue;

                Regex regex = new Regex(pattern);
                Match match = regex.Match(addr);

                while (match.Success)
                {
                    string replaceValue = match.Groups[0].Value;

                    if (replaceValue != "")
                    {
                        string oldold = addr;
                        addr = Regex.Replace(addr, oldValue, newValue);
                    }
                    match = match.NextMatch();
                }
            }

            //удаляем из адреса упоминание метро, если оно есть. В листе метро МСК и СПБ
            foreach (string subway in NameHelper.SubwayNames)
            {
                //без буквы м нельзя - много лишнего будет, например, есть станция Московская = область Московская
                if (addr.Contains(subway))
                {
                    addr = addr.Replace(subway, "");
                }
            }

            //Меняем римские на арабские
            if (addr.Contains('I') || addr.Contains('V') || addr.Contains('X') || addr.Contains('L'))
            {
                string pattern = @"I*V*I*V*X*I*V*I*L*I*V*I*V*X*I*V*I*";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(addr);

                while (match.Success)
                {
                    string romNumber = match.Groups[0].Value;
                    
                    if (romNumber != "")
                    {
                        string arabNumber = Decode(romNumber);
                        addr = addr.Replace(romNumber, arabNumber);
                    }
                    match = match.NextMatch();
                }
            }

            return addr;
        }

        private static readonly Dictionary<char, int> romanDigits =
            new Dictionary<char, int> {
                { 'I', 1 },
                { 'V', 5 },
                { 'X', 10 },
                { 'L', 50 },
                { 'C', 100 }
            };

        private static string Decode(string s)
        {
            int total = 0;
            int prev = 0;
            foreach (char c in s)
            {
                int current = romanDigits[c];
                if (prev == 0)
                {
                    prev = romanDigits[c];
                    total = current;
                }
                else
                {
                    if (prev < current)
                    {
                        total -= current;
                    }
                    else
                    {
                        total += current;
                    }
                }
            }
            return total < 0 ? (-total).ToString() : total.ToString();
        }






    }
}
