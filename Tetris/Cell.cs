using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public enum CellKind { Block, Border, Tetramino, FreeSpace }

    public class Cell

    {
        public bool isBlockOrBorder { get { return CellKind == CellKind.Block || CellKind == CellKind.Border; } }
        public CellKind CellKind { get; private set; }

        public override string ToString()
        {
            switch (CellKind)
            {
                case CellKind.Border:
                    return "* ";
                case CellKind.FreeSpace:
                    return "  ";
                case CellKind.Tetramino:
                    return "■ ";
                case CellKind.Block:
                    return " ";
                default:
                    return "  ";
            }

        }

        public Cell(CellKind cellKind) { CellKind = cellKind; }

        public void TransformToTetromino()
        {
            CellKind = CellKind.Tetramino;
        }
        public void TransformToFreeSpace()
        {
            CellKind = CellKind.FreeSpace;
        }
    }
}
