using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badgerati.Collection
{
    public class TableColumn
    {
        private string _header;
        public string Header
        {
            get { return _header; }
        }

        private List<object> _rows;
        public IList<object> Rows
        {
            get { return _rows; }
        }

        public int Count
        {
            get { return _rows.Count; }
        }

        public object this[int index]
        {
            get { return _rows[index]; }
            set { _rows[index] = value; }
        }



        public TableColumn(string header)
        {
            _header = header;
            _rows = new List<object>();
        }



        public void AddRow(object item)
        {
            _rows.Add(item);
        }

    }
}
