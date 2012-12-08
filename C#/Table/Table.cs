using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Badgerati.Collection
{
    public class Table
    {
        public int Width
        {
            get { return _headers.Count; }
        }

        public int Height
        {
            get { return _rows.Count; }
        }

        private List<string> _headers;
        public IList<string> Headers
        {
            get { return _headers; }
        }

        public bool HasHeaders
        {
            get { return _headers.Count > 0; }
        }

        private List<TableRow> _rows;
        public IList<TableRow> Rows
        {
            get { return _rows; }
        }

        public TableRow this[int index]
        {
            get { return this.GetRow(index); }
            set { this.UpdateRow(index, value); }
        }

        public TableColumn this[string header]
        {
            get { return GetColumn(header); }
            set { this.UpdateColumn(header, value); }
        }





        public Table()
        {
            _headers = new List<string>();
            _rows = new List<TableRow>();
        }
        
        public Table(string[] headers)
        {
            _headers = new List<string>(headers);
            _rows = new List<TableRow>();
        }

        public Table(int columns)
        {
            _headers = new List<string>();

            for (int i = 0; i < columns; i++)
            {
                _headers.Add(i.ToString());
            }

            _rows = new List<TableRow>();
        }




        protected TableRow GetRow(int index)
        {
            if (!HasHeaders)
                throw new IndexOutOfRangeException("The Table currently has no Headers");

            if (index < 0 || index >= _rows.Count)
                throw new IndexOutOfRangeException();

            return _rows[index];
        }




        public bool AddRow(object[] items)
        {
            if (!HasHeaders)
                return false;

            if (items.Length != _headers.Count)
                return false;

            TableRow row = new TableRow(_headers, items);
            _rows.Add(row);

            return true;
        }



        public void RemoveRow(int index)
        {
            if (index < 0 || index >= _rows.Count)
                throw new IndexOutOfRangeException();

            _rows.RemoveAt(index);
        }



        public bool RemoveRow(TableRow row)
        {
            return _rows.Remove(row);
        }



        protected bool UpdateRow(int index, TableRow row)
        {
            if (!HasHeaders)
                return false;

            if (index < 0 || index >= _rows.Count)
                throw new IndexOutOfRangeException();

            for (int i = 0; i < _rows[index].Count; i++)
            {
                _rows[index][_headers[i]] = row[_headers[i]];
            }

            return true;
        }



        public TableColumn GetColumn(string header)
        {
            if (!HasHeaders)
                throw new IndexOutOfRangeException("The Table currently has no Headers");

            TableColumn column = new TableColumn(header);

            for (int i = 0; i < _rows.Count; i++)
            {
                column.AddRow(_rows[i][header]);
            }

            return column;
        }




        public bool AddColumn(string header)
        {
            if (_headers.Contains(header))
                return false;

            _headers.Add(header);

            for (int i = 0; i < _rows.Count; i++)
            {
                _rows[i].AddItem(header);
            }

            return true;
        }




        public bool AddColumn(string header, object[] items)
        {
            if (_headers.Contains(header))
                return false;

            if (items.Length != _rows.Count())
                return false;

            _headers.Add(header);

            for (int i = 0; i < _rows.Count; i++)
            {
                _rows[i].AddItem(header, items[i]);
            }

            return true;
        }



        public bool RemoveColumn(string header)
        {
            if (!_headers.Contains(header))
                return false;

            _headers.Remove(header);

            for (int i = 0; i < _rows.Count(); i++)
            {
                _rows[i].RemoveItem(header);
            }

            return true;
        }




        protected bool UpdateColumn(string header, TableColumn column)
        {
            if (!_headers.Contains(header))
                return false;

            if (_rows.Count == 0 || !HasHeaders)
                return false;

            if (_rows.Count != column.Count)
                return false;

            for (int i = 0; i < _rows.Count; i++)
            {
                _rows[i][header] = column[i];
            }
            
            return true;
        }

    }
}
