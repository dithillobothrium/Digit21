using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using Common;

namespace Parser
{
    internal class AddressParser
    {
        private string _addr;
        private FullData _data;

        public FullData Process(FullData data)
        {
            _addr = data.address;
            _data = data;

            // CLeanup
            CleanupAddress();

            //split
            var words = _addr.Split(' ').Where(s => !string.IsNullOrEmpty(s));
            foreach (var word in words)
            {
                ClassifyWord(word);
                //ParseWord(word);
            }

            return _data;
        }

        private void ClassifyWord(string word)
        {
            
        }

        private void ParseWord(string word)
        {
            var found = NameHelper.SearchName(word);

        }

        private void CleanupAddress()
        {
            _addr = _addr.Replace("\"", ""); // remove quotes

            _addr = _addr.Replace(",", " ");

            _addr.TrimStart('(');

            _addr = Regex.Replace(_addr, @"\(.+\)", "");

            //удаляем из адреса упоминание метро, если оно есть. В листе метро МСК и СПБ
            foreach (string subway in NameHelper.SubwayNames)
            {
                foreach (string prefix in NameHelper.SubwayPrefix)
                {
                    //без буквы м нельзя - много лишнего будет, например, есть станция Московская = область Московская
                    if (_addr.Contains(prefix + subway))
                    {
                        _addr = _addr.Replace(prefix + subway, "");
                    }
                }
            }

            //Меняем римские на арабские
            if (_addr.Contains('I') || _addr.Contains('V') || _addr.Contains('X') || _addr.Contains('L'))
            {
                string pattern = @"I*V*I*V*X*I*V*I*L*I*V*I*V*X*I*V*I*";
                Regex regex = new Regex(pattern);
                Match match = regex.Match(_addr);

                while (match.Success)
                {
                    string romNumber = match.Groups[0].Value;
                    
                    if (romNumber != "")
                    {
                        string arabNumber = Decode(romNumber);
                        _addr = _addr.Replace(romNumber, arabNumber);
                    }
                    match = match.NextMatch();
                }
            }

            //var startIndex = 0;
            //while (true)
            //{
            //    var index = _addr.IndexOf('-', startIndex);

            //    if (index < 0)
            //        break;

            //    if (index > 0 && index < _addr.Length - 1)
            //    {
            //        if (char.IsDigit(_addr[index - 1]) && char.IsDigit(_addr[index + 1]))
            //        {
            //            var ar = _addr.ToCharArray();
            //            ar[index] = '/';
            //            _addr = new string(ar);
            //        }
            //    }

            //    startIndex = index + 1;
            //}

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
