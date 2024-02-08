namespace TicTacToe
{
    internal class Program
    {
        const char Player1Marker = 'X';
        const char Player2Marker = 'O';

        static char[,] playField =
        {
            {'1','2','3'},
            {'4','5','6'},
            {'7','8','9'}
        };
        static char[,] playFieldIntial = (char[,])playField.Clone();

        static int turns = 0;
        static int input;

        static void Main(string[] args)
        {
            bool player1Turn = false;

            do
            {
                SetField();

                player1Turn = !player1Turn;

                do
                {
                    Console.Write("\nPlayer {0} Make your move: ", player1Turn == true ? 1 : 2);

                    if (!int.TryParse(Console.ReadLine(), out input) || input < 1 || input > 9)
                    {
                        Console.WriteLine("Invalid input! Please enter a number between 1 and 9.");
                        continue;
                    }

                    if (!IsCellAvailable(input))
                    {
                        Console.WriteLine("Invalid move! Cell already taken.");
                        continue;
                    }

                    break;
                } while (true);

                SetXorOs(player1Turn, input);

                if (CheckWinner(player1Turn ? Player1Marker : Player2Marker))
                {
                    Console.WriteLine("\nPlayer {0} has won!", player1Turn ? 1 : 2);
                    Console.WriteLine("Please press any key to reset the game.");
                    Console.ReadKey();
                    Console.Clear();
                    playField = playFieldIntial;
                    turns = 0;
                    continue;
                }

                turns++;
                if (turns == 9)
                {
                    Console.WriteLine("\nThe game is a tie!");
                    Console.WriteLine("Please press any key to reset the game.");
                    Console.ReadKey();
                    Console.Clear();
                    playField = playFieldIntial;
                    turns = 0;
                }

            } while (true);
        }

        public static bool CheckWinner(char playerMarker)
        {
            for (int i = 0; i < 3; i++)
            {
                if (playField[i, 0] == playerMarker && playField[i, 1] == playerMarker && playField[i, 2] == playerMarker
                    || playField[0, i] == playerMarker && playField[1, i] == playerMarker && playField[2, i] == playerMarker)
                    return true;
            }

            if (playField[0, 0] == playerMarker && playField[1, 1] == playerMarker && playField[2, 2] == playerMarker
                || playField[0, 2] == playerMarker && playField[1, 1] == playerMarker && playField[2, 0] == playerMarker)
                return true;

            return false;
        }

        public static bool IsCellAvailable(int input)
        {
            int row = (input - 1) / 3;
            int col = (input - 1) % 3;

            return playField[row, col] != Player1Marker && playField[row, col] != Player2Marker;
        }

        public static void SetField()
        {
            Console.WriteLine("        |       |       ");
            Console.WriteLine("    {0}   |   {1}   |   {2}   ", playField[0, 0], playField[0, 1], playField[0, 2]);
            Console.WriteLine(" _______|_______|_______");

            Console.WriteLine("        |       |       ");
            Console.WriteLine("    {0}   |   {1}   |   {2}   ", playField[1, 0], playField[1, 1], playField[1, 2]);
            Console.WriteLine(" _______|_______|_______");

            Console.WriteLine("        |       |       ");
            Console.WriteLine("    {0}   |   {1}   |   {2}   ", playField[2, 0], playField[2, 1], playField[2, 2]);
            Console.WriteLine("        |       |       ");
        }

        static void SetXorOs(bool player, int input)
        {
            Console.Clear();
            char playerMove = player ? Player1Marker : Player2Marker;

            int row = (input - 1) / 3;
            int col = (input - 1) % 3;

            playField[row, col] = playerMove;
        }
    }
}
