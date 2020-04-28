using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudocker
{
    public class PlayGridValidator
    {
        private readonly SmallGrid[] _smallGrids;

        public PlayGridValidator(SmallGrid [] smallGrids)
        {
            _smallGrids = smallGrids;
        }

        public void ValidateInitialState()
        {
            if (_smallGrids.Length != 9)
            {
                throw new ArgumentException("bad source length");
            }
        }

        //public bool IsFinalState()
        //{
          
        //}
    }
}
