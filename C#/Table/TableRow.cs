using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badgerati.Collection
{
    public class TableRow
    {
        private Dictionary<string, object> _row;

        public int Count
        {
            get { return _row.Count; }
        }

        public object this[string key]
        {
            get { return this.GetItem(key); }
            set { _row[key] = value; }
        }



        protected object GetItem(string key)
        {
            if (_row.ContainsKey(key))
            {
                return _row[key];
            }
            return null;
        }



        public TableRow(IList<string> keys, object[] items)
        {
            _row = new Dictionary<string, object>();
            for (int i = 0; i < keys.Count; i++)
            {
                _row.Add(keys[i], items[i]);
            }
        }



        public void AddHeader(string header)
        {
            _row.Add(header, null);
        }



        public void AddHeader(string header, object item)
        {
            _row.Add(header, item);
        }

    }
}
