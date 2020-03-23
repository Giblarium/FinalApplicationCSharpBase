using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class TetraminoManager
    {
        public TetraminoManager()
        {
            InitDefaultTetromino();
        }

        private readonly Tetramino[] defaultTetraminos = new Tetramino[7];
        private void InitDefaultTetromino()
        {
            Tetramino tetraminoI = new Tetramino();
            tetraminoI.Kind = TetrominoKind.I;
            tetraminoI.Units[0] = new Unit(0, 4);
            tetraminoI.Units[1] = new Unit(1, 4);
            tetraminoI.Units[2] = new Unit(2, 4);
            tetraminoI.Units[3] = new Unit(3, 4);
            defaultTetraminos[0] = tetraminoI;

            Tetramino tetraminoO = new Tetramino();
            tetraminoO.Kind = TetrominoKind.O;
            tetraminoO.Units[0] = new Unit(0, 4);
            tetraminoO.Units[1] = new Unit(0, 5);
            tetraminoO.Units[2] = new Unit(1, 4);
            tetraminoO.Units[3] = new Unit(1, 5);
            defaultTetraminos[1] = tetraminoO;

            Tetramino tetraminoT = new Tetramino();
            tetraminoT.Kind = TetrominoKind.T;
            tetraminoT.Units[0] = new Unit(0, 5);
            tetraminoT.Units[1] = new Unit(0, 4);
            tetraminoT.Units[2] = new Unit(0, 6);
            tetraminoT.Units[3] = new Unit(1, 5);
            defaultTetraminos[2] = tetraminoT;

            Tetramino tetraminoJ = new Tetramino();
            tetraminoJ.Kind = TetrominoKind.J;
            tetraminoJ.Units[0] = new Unit(0, 4);
            tetraminoJ.Units[1] = new Unit(1, 4);
            tetraminoJ.Units[2] = new Unit(2, 4);
            tetraminoJ.Units[3] = new Unit(2, 3);
            defaultTetraminos[3] = tetraminoJ;

            Tetramino tetraminoL = new Tetramino();
            tetraminoL.Kind = TetrominoKind.L;
            tetraminoL.Units[0] = new Unit(0, 4);
            tetraminoL.Units[1] = new Unit(1, 4);
            tetraminoL.Units[2] = new Unit(2, 4);
            tetraminoL.Units[3] = new Unit(2, 5);
            defaultTetraminos[4] = tetraminoL; 

            Tetramino tetraminoS = new Tetramino();
            tetraminoS.Kind = TetrominoKind.S;
            tetraminoS.Units[0] = new Unit(0, 5);
            tetraminoS.Units[1] = new Unit(0, 4);
            tetraminoS.Units[2] = new Unit(1, 4);
            tetraminoS.Units[3] = new Unit(1, 3);
            defaultTetraminos[5] = tetraminoS; 


            Tetramino tetraminoZ = new Tetramino();
            tetraminoZ.Kind = TetrominoKind.Z;
            tetraminoZ.Units[0] = new Unit(0, 3);
            tetraminoZ.Units[1] = new Unit(0, 4);
            tetraminoZ.Units[2] = new Unit(1, 4);
            tetraminoZ.Units[3] = new Unit(1, 5);
            defaultTetraminos[6] = tetraminoZ;

        }
        public Tetramino GetRandomTetramino()
        {
            return defaultTetraminos[6];
        }
    }
}
