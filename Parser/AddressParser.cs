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
                ParseWord(word);
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

         



        
    }
}
