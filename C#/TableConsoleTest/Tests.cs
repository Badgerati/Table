using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Badgerati.Collection;

namespace TableConsoleTest
{
    public class Tests
    {


        public void defaultTableWithStringItems_Success()
        {
            Table table = new Table(2);
            table.AddRow(new object[] { "hello", "bye" });
            TableRow tr = table[0];

            Assert.AreEqual("hello", tr["0"]);
            Assert.AreEqual("bye", tr["1"]);
        }



        public void defaultTableWithMultipleItems_Success()
        {
            Table table = new Table(2);
            table.AddRow(new object[] { "hello", 100 });
            TableRow tr = table[0];

            Assert.AreEqual("hello", tr["0"]);
            Assert.AreEqual(100, tr["1"]);
        }



        public void tableWithKeysAndStringItems_Success()
        {
            Table table = new Table(new string[] { "name", "gender" });
            table.AddRow(new object[] { "matt", "male" });
            TableRow tr = table[0];

            Assert.AreEqual("matt", tr["name"]);
            Assert.AreEqual("male", tr["gender"]);
        }



        public void tableWithKeysAndMultipleItems_Success()
        {
            Table table = new Table(new string[] { "name", "age" });
            table.AddRow(new object[] { "matt", 22 });
            TableRow tr = table[0];

            Assert.AreEqual("matt", tr["name"]);
            Assert.AreEqual(22, tr["age"]);
        }



        public void tableWithKeysAndMultipleItems_Fail()
        {
            Table table = new Table(new string[] { "name", "age" });
            table.AddRow(new object[] { "matt", 22 });
            TableRow tr = table[0];

            Assert.AreNotEqual("matt", tr["nme"]);
            Assert.AreNotEqual(27, tr["age"]);
        }



        public void tableWithKeysAndMultipleRows_Success()
        {
            Table table = new Table(new string[] { "name", "age" });
            table.AddRow(new object[] { "matt", 22 });
            table.AddRow(new object[] { "mike", 20 });
            table.AddRow(new object[] { "becky", 19 });

            TableRow tr1 = table[0];
            Assert.AreEqual("matt", tr1["name"]);
            Assert.AreEqual(22, tr1["age"]);

            TableRow tr2 = table[1];
            Assert.AreEqual("mike", tr2["name"]);
            Assert.AreEqual(20, tr2["age"]);

            TableRow tr3 = table[2];
            Assert.AreEqual("becky", tr3["name"]);
            Assert.AreEqual(19, tr3["age"]);
        }




        public void TestHeigtAndWidth_Success()
        {
            Table table = new Table(new string[] { "name", "age" });
            table.AddRow(new object[] { "matt", 22 });
            table.AddRow(new object[] { "mike", 20 });
            table.AddRow(new object[] { "becky", 19 });

            Assert.AreEqual(3, table.Height);
            Assert.AreEqual(2, table.Width);
        }



        public void ChangeItemInRow_Success()
        {
            Table table = new Table(new string[] { "name", "age" });
            table.AddRow(new object[] { "matt", 22 });
            table.AddRow(new object[] { "mike", 20 });
            table.AddRow(new object[] { "becky", 19 });

            table[1]["name"] = "bob";
            table[1]["age"] = 27;

            Assert.AreEqual("bob", table[1]["name"]);
            Assert.AreEqual(27, table[1]["age"]);
        }




        /*public void ChangeTableRow_Success()
        {
            Table table = new Table(new string[] { "name", "age" });
            table.insertRow(new object[] { "matt", 22 });
            table.insertRow(new object[] { "mike", 20 });
        }*/


    }
}
