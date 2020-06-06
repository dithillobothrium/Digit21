using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Parser
{

    public static class NameHelper
    {
        //public static NameData[] NameData;

        static NameHelper()
        {

        }

        public static string[] SubwayNames = File.ReadAllLines("metro.txt");
 
    }
}
