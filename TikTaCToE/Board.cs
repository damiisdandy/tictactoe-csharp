using System;


namespace TikTaCToE
{
    class Board
    {
        static private char[,] boardGUI = {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
        };

        static private bool[,] boardLocation = {
            {false, false, false },
            {false, false, false },
            {false, false, false }
        };

        /// <summary>
        /// Renders the GUI (re-render on call)
        /// </summary>
        
        static public void RenderBoard()
        {
            for (int i = 0; i < boardGUI.GetLength(0); i++)
            {
                for (int j = 0; j < boardGUI.GetLength(1); j++)
                {
                    Console.Write($"\t{boardGUI[i, j]}\t" + (j == 2 ? "\n" : ""));
                }
            }
        }
        
        /// <summary>
        /// Set Player's location on the board
        /// </summary>
        /// <param name="dims"></param>
        /// <param name="character"></param>
        static public void SetPlayerLocation(int[] dims, char character)
        {

            boardGUI[dims[0], dims[1]] = character;
            boardLocation[dims[0], dims[1]] = true;
        }

        /// <summary>
        /// Find Winner by character
        /// </summary>
        /// <param name="character">player character</param>
        /// <returns>if player characters all match horizontally, vertically, diagonally</returns>
        static public bool IsThereAWinner(char character)
        {
            char[] equalArray = { character, character, character };
            char[] horizontalDerivedArray = new char[3];
            char[] verticalDerivedArray = new char[3];
            char[] rightDiagonalDerivedArray = new char[3];
            char[] leftDiagonalDerivedArray = new char[3];

            for (int i = 0; i < boardGUI.GetLength(0); i++)
            {
                for (int j=0; j < boardGUI.GetLength(1); j++)
                {
                    horizontalDerivedArray[j] = boardGUI[i, j];
                    verticalDerivedArray[j] = boardGUI[j, i];
                    // these 2 can only be identified if the array is done looping
                    if (i == j)
                    {
                        rightDiagonalDerivedArray[j] = boardGUI[i, j];
                    }
                    if (i + j == 2)
                    {
                        leftDiagonalDerivedArray[j] = boardGUI[i, j];
                    }
                }
                if(Program.CompareArray(horizontalDerivedArray, equalArray) 
                    || Program.CompareArray(verticalDerivedArray, equalArray)
                    ||Program.CompareArray(rightDiagonalDerivedArray, equalArray)
                    || Program.CompareArray(leftDiagonalDerivedArray, equalArray))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Reset BoardGUI and location values
        /// </summary>
        static public void ResetBoard()
        {
            int counter = 1;
            for(int i = 0; i < boardGUI.GetLength(0); i++ )
            {
                for(int j = 0; j < boardGUI.GetLength(1); j++)
                {
                    boardGUI[i, j] = char.Parse(counter.ToString());
                    boardLocation[i, j] = false;
                    counter++;
                }
            }
        }

        /// <summary>
        /// Check if location is already occupied
        /// </summary>
        /// <param name="dims">int array to represent axis e.g {1,2}</param>
        /// <returns>if location is available or not</returns>
        static public bool IsLocationAvailable(int[] dims)
        {
            return boardLocation[dims[0], dims[1]];
        }
    }
}
