﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public enum MoveDirection {Down, InstantlyDown, Right, Left, Rotate }

    class Game
    {
        private Board board;

        public Game()
        {
            Init();
        }
        private void Init() {
            Console.CursorVisible = false;
            board = new Board();
            Console.WindowWidth = 66;
            Console.WindowHeight = 32;
            board.Show();
        }
        private static bool gameState;
        public static void EndGame() {
            gameState = false;
        }

        public void Start() 
        {
            gameState = true;
            ConsoleKey consoleKey = ConsoleKey.Backspace;
            while (gameState)
            {
                switch (consoleKey)
                {
                    case ConsoleKey.UpArrow:
                        board.MoveTetromino(MoveDirection.Rotate);
                        break;
                    case ConsoleKey.LeftArrow:
                        board.MoveTetromino(MoveDirection.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        board.MoveTetromino(MoveDirection.Right);
                        break;
                    case ConsoleKey.DownArrow:
                        board.MoveTetromino(MoveDirection.Down);
                        break;
                    case ConsoleKey.Spacebar:
                        board.MoveTetromino(MoveDirection.InstantlyDown);
                        break;
                }
                board.Show();
                consoleKey = Console.ReadKey(true).Key;
            }

            Console.SetCursorPosition(0, 24);
            Console.WriteLine("Игра завершена!");
        }
    }
}
