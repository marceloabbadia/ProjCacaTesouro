using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacaTesouro
{
    public interface IElements
    {
        public int[,] Coordinates { get; set; }

        public int[,] Move(int coordinatesX, int coordinatesY);


    }
}
