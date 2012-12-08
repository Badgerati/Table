using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Badgerati.Collection;

namespace TableConsoleTest
{
    public class Program
    {


        static void Main(string[] args)
        {
            Table table = new Table(2);
            table.AddRow(new object[] { "hello", 100 });

            TableRow tr = table[0];
            Console.WriteLine(tr["0"] + " -- " + tr["1"]);

            table.AddColumn("age");
            table[0]["age"] = 2;

            tr = table[0];
            Console.WriteLine(tr["0"] + " -- " + tr["1"] + " -- " + tr["age"]);


        }



    }
}
