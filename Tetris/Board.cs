using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Board
    {
        private readonly Cell[][] cells;
        private readonly int boardHeight;
        private readonly int boardWidth;

        private Tetramino currentTetramino;
        private readonly TetraminoManager manager;

        public Board()
        {
            boardHeight = 24;
            boardWidth = 10;
            cells = new Cell[boardHeight][];
            manager = new TetraminoManager();

            currentTetramino = manager.GetRandomTetramino();

            InitFreeSpaces();
            InitBorder();

            AddTetrominoToBoard();
        }

        private void AddTetrominoToBoard()
        {
            foreach (Unit unit in currentTetramino.Units)

            {
                cells[unit.Row][unit.Column].TransformToTetromino();
            }
        }

        private void InitBorder()
        {
            for (int i = 0; i < boardHeight; i++)
            {
                cells[i][0] = new Cell(CellKind.Border);
                cells[i][boardWidth - 1] = new Cell(CellKind.Border);
            }

            for (int i = 0; i < boardWidth; i++)
            {
                cells[boardHeight - 1][i] = new Cell(CellKind.Border);
            }

        }

        private void InitFreeSpaces()
        {
            for (int i = 0; i < boardHeight; i++)
            {
                cells[i] = new Cell[boardHeight];
                for (int j = 1; j < boardWidth-1; j++)
                {
                    cells[i][j] = new Cell(CellKind.FreeSpace);
                }
            }
        }

        public void Show()
        {
            for (int i = 0; i < boardHeight; i++)
            {
                Console.SetCursorPosition(0, i);
                for (int j = 0; j < boardWidth; j++)
                {
                    Console.Write(cells[i][j]);
                }
            }
        }
        public void MoveTetromino(MoveDirection direction) {
            HideTeromino();
            switch (direction)
            {
                case MoveDirection.Down:
                    if (!CanMoveDown(1))
                    {
                        PlaceTetramino(instantly: false);
                    }
                    else
                    {
                        for (int i = 0; i < currentTetramino.Units.Length; i++)
                        {
                            currentTetramino.Units[i].Row += 1;
                        }
                    }
                    break;
                case MoveDirection.InstantlyDown:
                    PlaceTetramino(instantly: true);
                    break;
                case MoveDirection.Right:
                case MoveDirection.Left:
                    bool right = direction == MoveDirection.Right;
                    int offset = right ? 1 : -1;
                    if (ClashWithBlocksOrBorder(currentTetramino, offset))
                        break;
                    for (int i = 0; i < currentTetramino.Units.Length; i++)
                    {
                        currentTetramino.Units[i].Column = currentTetramino.Units[i].Column + offset;
                    }
                    break;
            }
            AddTetrominoToBoard();
        }

        private void PlaceTetramino(bool instantly)
        {
            if (instantly)
            {
                MoveDownInstantly();
            }
            foreach (Unit unit in currentTetramino.Units)
            {
                cells[unit.Row][unit.Column].TransformToBlock();
            }

            if (EndGame(cells[4]))
            {
                Game.EndGame();
                return;
            }


            currentTetramino = manager.GetRandomTetramino();
        }

        private bool EndGame(Cell[] cell)
        {
            for (int i = 0; i < 9; i++)
            {
                if (cell[i].CellKind == CellKind.Block)
                {
                    return true;
                }
            }
            return false;
        }

        private void MoveDownInstantly()
        {
            int step = 0;
            while (true)
            {
                if (!CanMoveDown(step + 1))
                {
                    for (int i = 0; i < currentTetramino.Units.Length; i++)
                    {
                        currentTetramino.Units[i].Row = currentTetramino.Units[i].Row + step;
                    }
                    break;
                }
                step++;

            }

        }

        private bool CanMoveDown(int step)
        {
            foreach (Unit unit in currentTetramino.Units)
            {
                if (cells[unit.Row + step][unit.Column].IsBlockOrBorder)
                {
                    return false;
                }

            };
            return true;
        }

        private bool ClashWithBlocksOrBorder(Tetramino currentTetramino, int offset = 0)
        {
            foreach (Unit unit in currentTetramino.Units)
            {
                if (unit.Column + offset < 0)
                    return true;
                if (unit.Column + offset > 23)
                    return true;
                if (cells[unit.Row][unit.Column + offset].IsBlockOrBorder)
                    return true;
            }
            return false;
        }

        private void HideTeromino()
        {
            foreach (Unit unit in currentTetramino.Units)
            {
                cells[unit.Row][unit.Column].TransformToFreeSpace();
            }
        }
    }

}
