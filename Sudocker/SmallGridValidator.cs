using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudocker
{
    public class SmallGridValidator
    {
        int[] source;
        public SmallGridValidator(int [] source)
        {
            this.source = source;           
        }

        public void ValidateInitialState()
        {
            if (source.Length != 9)
            {
                throw new ArgumentException("bad source length");
            }

            var items = source.AsEnumerable().Where(x=> !new List<int> { -1 }.Contains(x));

            if (items.Distinct().Count() != items.Count())
            {
                throw new ArgumentException("bad source input. Items must be unique");
            }
        }
    }
}
