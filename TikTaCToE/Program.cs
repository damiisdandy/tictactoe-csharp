using System;

namespace TikTaCToE
{
    class Program
    {
        static void Main(string[] args)
        {
            int userInput;
            int counter = 0;
            Player player1 = new Player("Player One", 'X');
            Player player2 = new Player("Player Two", 'O');

            while (true)
            {
                Board.RenderBoard();
                // using counter to display which player is next (with the use of modulus %)
                Player activePlayer = counter % 2 == 0 ? player1 : player2;
                Console.Write("{0}: Choose your field >> ", activePlayer.Name);
                bool isValidInput = int.TryParse(Console.ReadLine(), out userInput);
                int[] selectedLocation = IntToLocationAxis(userInput);
                if (!isValidInput || userInput < 1 || userInput > 9)
                {
                    Console.WriteLine("Incorrect input, only input values shown on board");
                    continue;
                }
                if (Board.IsLocationAvailable(selectedLocation))
                {
                    Console.WriteLine("Location already occupied");
                    continue;
                }
                Board.SetPlayerLocation(selectedLocation, activePlayer.Character);
                if (Board.IsThereAWinner(activePlayer.Character))
                {
                    Board.RenderBoard();
                    Console.WriteLine("{0} Won!", activePlayer.Name);
                    Console.Write("Type r to play again or any other key to exit >> ");
                    string newUserInput = Console.ReadLine();
                    if (newUserInput.Equals("r"))
                    {
                        counter = 0;
                        Board.ResetBoard();
                    }
                    else
                    {
                        break;
                    }
                } else
                {
                    counter++;
                }
                Console.Clear();
            }
        }
        /// <summary>
        ///  Map user input to matix dimensions e.g 1 => {0,0} and 2 => {0,1}
        /// </summary>
        /// <param name="num">Int value</param>
        /// <returns>one-dimensional array of int values representing board co-ordinates</returns>
        static int[] IntToLocationAxis(int num)
        {
            switch (num)
            {
                case 1:
                    return new int[]{0, 0};
                case 2:
                    return new int[] { 0, 1 };
                case 3:
                    return new int[] { 0, 2 };
                case 4:
                    return new int[] { 1, 0 };
                case 5:
                    return new int[] { 1, 1 };
                case 6:
                    return new int[] { 1, 2 };
                case 7:
                    return new int[] { 2, 0 };
                case 8:
                    return new int[] { 2, 1 };
                case 9:
                    return new int[] { 2, 2 };
                default:
                    return new int[] { 0, 0 };
            }
        }

        static public bool CompareArray(char[] array1, char[] array2)
        {
            for (int i = 0; i < array1.Length; i++)
            {
                if (!array1[i].Equals(array2[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}

