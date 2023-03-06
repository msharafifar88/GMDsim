using System.Collections.Generic;

namespace BL.Calculation_Core.SparseMatrixGMDC
{
    public class SparseMatrix<T>
    {
        public long Width { get; private set; }
        public long Height { get; private set; }
        public long Size { get; private set; }

        private Dictionary<long, T> _cells = new Dictionary<long, T>();


        public SparseMatrix(long w, long h)
        {
            this.Width = w;
            this.Height = h;
            this.Size = w * h;
        }


        public bool IsCellEmpty(long row, long col)
        {
            long index = row * Width + col;
            return _cells.ContainsKey(index);
        }

        public T this[long row, long col]
        {
            get
            {
                long index = row * Width + col;
                T result;
                _cells.TryGetValue(index, out result);
                return result;
            }
            set
            {
                long index = row * Width + col;
                _cells[index] = value;
            }
        }

    }
}
