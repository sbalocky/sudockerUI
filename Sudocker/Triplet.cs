using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudocker
{
    public class Triplet
    {
        private readonly int _a;
        private readonly int _b;
        private readonly int _c;       

        public Triplet(int a, int b, int c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public int Item0 { get { return _a; } }

        public int Item1 { get { return _b; } }

        public int Item2 { get { return _c; } }

        public IEnumerable<int> All { get { return new List<int> { _a, _b, _c }; } }

        public int Sum()
        {
            return _a + _c + _b;
        }
    }
}
