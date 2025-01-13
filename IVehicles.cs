using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacaTesouro
{
    public interface IVehicles
    {
        public int[,] Coordinates { get; set; }

        public int[,] Move(int coordinatesX, int coordinatesY, int vehicle1X, int vehicle1Y, int vehicle2X, int vehicle2Y);

    }
}
