using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableConsoleTest
{
    public abstract class Assert
    {
        public static void IsTrue(bool value)
        {
            if (!value) { throw new Exception("True expected, but False passed."); }
        }


        public static void IsFalse(bool value)
        {
            if (value) { throw new Exception("False expected, but True passed."); }
        }


        public static void AreEqual(object obj1, object obj2)
        {
            if (!obj1.Equals(obj2)) { throw new Exception("Two equal objects expected, but not passed."); }
        }

        public static void AreEqual(object obj1, object obj2, string msg)
        {
            if (!obj1.Equals(obj2)) { throw new Exception(msg); }
        }


        public static void AreNotEqual(object obj1, object obj2)
        {
            if (obj1.Equals(obj2)) { throw new Exception("Two non-equal objects expected, but not passed."); }
        }

        public static void AreNotEqual(object obj1, object obj2, string msg)
        {
            if (obj1.Equals(obj2)) { throw new Exception(msg); }
        }
    }
}
