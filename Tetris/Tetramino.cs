using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public enum TetrominoKind {I, O, T, J, L, S, Z}
    struct Unit
    {
        public Unit(int row, int column) {
            Row = row;
            Column = column;
        }

        public int Row { get;  set; }
        public int Column { get;  set; }
    }
    class Tetramino
    {
        public Unit[] Units = new Unit[4];
        public TetrominoKind Kind { get; set; }
    }
}
