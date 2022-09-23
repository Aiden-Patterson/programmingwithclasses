using System;

// Tic-Tac-Toe, by Aiden Patterson
namespace TicTacToe
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Create the empty board
            List<string> game = new List<string>();
            int input;
            for(int i = 0; i < 9; i++)
            {
                game.Add(" ");
            }
            displayBoard(game);
            // game loop
            do{
                do{
                    Console.Write(isXTurn(game) + "'s turn to choose a square (1-9): ");
                    input = int.Parse(Console.ReadLine()) - 1;
                    if(!game[input].Equals(" "))
                        Console.WriteLine("That spot is taken, please try again");
                }while(!game[input].Equals(" "));
                game[input] = isXTurn(game);
                displayBoard(game);
            }while(!isOver(game));
            Console.WriteLine("Game Over. Thanks for playing!");
        }

        public static void displayBoard(List<string> game)
        {
            // Display the current board
            Console.WriteLine(" " + game[0] + " | " + game[1] + " | " + game[2]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + game[3] + " | " + game[4] + " | " + game[5]);
            Console.WriteLine("---+---+---");
            Console.WriteLine(" " + game[6] + " | " + game[7] + " | " + game[8]);
        }

        public static string isXTurn(List<string> game)
        {
            // Determine whose turn it is and return the character that is
            int turnCount = 0;
            for(int i = 0; i < 9; i++)
            {
                if(!game[i].Equals(" "))
                    turnCount++;
            }
            if(turnCount % 2 == 0)
                    return "X";
                else
                    return "O";
        }

        public static bool isOver(List<string> game)
        {
            // Determine if the game is over. 
            //I just did this in python for another class so I converted the code from that
            //check rows
            for(int row = 0; row < 3; row++)
            {
                if(!game[row * 3].Equals(" "))
                    if(game[row * 3].Equals(game[row * 3 + 1]) && game[row * 3 + 1].Equals(game[row * 3 + 2]))
                        return true;
            }
            //check columns
            for(int col = 0; col < 3; col++)
            {
                if(!game[col].Equals(" "))
                    if(game[col].Equals(game[3 + col]) && game[3 + col].Equals(game[6 + col]))
                        return true;
            }
            // check diagonals
            if(!game[4].Equals(" "))
                if(game[0].Equals(game[4]) && game[4].Equals(game[8]) || game[2].Equals(game[4]) && game[4].Equals(game[6]))
                    return true;
            return false;
        }
    }
}
