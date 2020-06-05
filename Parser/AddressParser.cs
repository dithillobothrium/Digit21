using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
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
                ParseWord(word);
            }

            return _data;
        }

        private void ParseWord(string word)
        {
            // check if socr 
            // if(socr) detect name    //forward
            // else                    //backward
            // check region
            // then city
            // then street
            // then other
            
        }

        private void CleanupAddress()
        {
            _addr = _addr.Replace("\"", ""); // remove quotes

            _addr = _addr.Replace(",", " ");

            _addr.TrimStart('(');

            var lastIndexOfBr1 = _addr.LastIndexOf('(');
            var lastIndexOfBr2 = _addr.LastIndexOf(')');
            if (lastIndexOfBr1 > 0 && lastIndexOfBr2 > lastIndexOfBr1)
            {
                _addr = _addr.Substring(0, lastIndexOfBr1);
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
