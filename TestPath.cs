using System;
using System.IO;

namespace UsersTestWebApi
{
    public class TestPath
    {
        public static void TestLog()
        {
            string localFilePath1 = @"Libs\myfile.dll";
            string localFilePath2 = "Libs\\myfile.dll";

            //1:
            string fullPath1 = Path.GetFullPath(localFilePath1);
            Console.WriteLine("GetFullPath('{0}') returns '{1}'",
                fullPath1, localFilePath1);

            //1:
            string fullPath2 = Path.GetFullPath(localFilePath2);
            Console.WriteLine("GetFullPath('{0}') returns '{1}'",
                fullPath2, localFilePath2);
        }
    }
}
