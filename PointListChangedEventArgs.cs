using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    public class PointListChangedEventArgs : EventArgs
    {
        public PointListChangedOperations Operation { get; set; }
        public enum PointListChangedOperations
        {
            Unknown,
            Add,
            Remove,
            Insert,
            Clear,
            Update
        }
        public PointListChangedEventArgs(PointListChangedOperations p)
        {
            Operation = p;
        }
    }
}
