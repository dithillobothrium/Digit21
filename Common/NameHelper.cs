using System.IO;

namespace Common
{

    public static class NameHelper
    {
        //public static NameData[] NameData;

        static NameHelper()
        {

        }

        public static string[] SubwayNames = File.ReadAllLines(Path.Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location), "metro.txt"));
 
    }
}
