using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentCustomList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            
            Console.WriteLine("Custom List Class Example");

            CustomList<string> myList = new CustomList<string>();
            myList.Add("Hello");
            myList.AddAtIndex("World", 1);


            //Explanation: Test your CustomList's functionality, including add/remove operations and index-based manipulations.

        }
    }
    
}
