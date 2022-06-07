namespace Day4
{
    internal class Program
    {
        private static List<Board> CloneBoardList(List<Board> boards)
        {
            List<Board> output = new List<Board>();
            foreach (Board board in boards)
            {
                output.Add(new Board(board));
            }
            return output;
        }

        private static List<Board> InputBoards(int boardSize)
        {
            List<Board> output = new List<Board>();
            List<BoardEntry> boardInput = new List<BoardEntry>();
            bool valid = true;
            Console.Write("Start of board numbers input (Invalid input to end)\n");
            while (valid)
            {
                string? input = Console.ReadLine();
                if (input != null)
                {
                    string[] inputSplit = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                    foreach (string split in inputSplit)
                    {
                        if (Int32.TryParse(split, out int number))
                        {
                            boardInput.Add(new BoardEntry(number));
                            if (boardInput.Count == boardSize * boardSize)
                            {
                                output.Add(new Board(boardInput, boardSize));
                                boardInput = new List<BoardEntry>();
                            }
                        }
                        else
                        {
                            valid = false;
                            break;
                        }
                    }
                }
                else
                {
                    valid = false;
                }
            }
            Console.Write("End of board numbers input\n\n");
            return output;
        }

        private static List<int> InputDrawnNumbers()
        {
            List<int> output = new List<int>();
            Console.Write("Start of drawn numbers input (X,X,... Invalid input to end)\n");
            string? input = Console.ReadLine();
            if (input != null)
            {
                string[] inputSplit = input.Split(',', System.StringSplitOptions.RemoveEmptyEntries);
                foreach (string split in inputSplit)
                {
                    if (Int32.TryParse(split, out int number))
                    {
                        output.Add(number);
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.Write("End of drawn numbers input\n\n");
            return output;
        }

        private static void PlayBingoFirstToWin(List<int> inputDrawnNumbers, List<Board> inputBoards)
        {
            List<Board> cloneBoards = CloneBoardList(inputBoards);
            List<BoardWin> boardWin = new List<BoardWin>();

            // Find first winning boards and winning number
            Console.Write("Play bingo first to win\n");
            for (int i = 0; i < inputDrawnNumbers.Count && boardWin.Count == 0; i++)
            {
                int drawnNumber = inputDrawnNumbers[i];
                Console.Write("Number drawn: {0}\n", drawnNumber);
                for (int j = 0; j < cloneBoards.Count; j++)
                {
                    Board board = cloneBoards[j];
                    for (int k = 0; k < board.Entries.Count; k++)
                    {
                        BoardEntry entry = board.Entries[k];
                        if (entry.Number == drawnNumber)
                        {
                            entry.Active = true;
                            int column = k % board.Size;
                            int row = k / board.Size;

                            bool wonColumn = board.CheckIfColumnHaveWon(column);
                            bool wonRow = board.CheckIfRowHaveWon(row);
                            if (wonColumn || wonRow)
                            {
                                boardWin.Add(new BoardWin(j, drawnNumber));
                            }
                        }
                    }
                }
            }
            if (boardWin.Count > 0)
            {
                foreach (BoardWin entry in boardWin)
                {
                    int index = entry.Index;
                    int number = entry.Number;
                    Console.Write("Winning board: {0}\n", index);
                    Console.Write("Winning number: {0}\n", number);
                    Console.Write("Score: {0}\n", cloneBoards[index].Score(number));
                    Console.Write(cloneBoards[index] + "\n\n");
                }
            }
            else
            {
                Console.Write("No winning boards :(\n");
            }
        }

        private static void PlayBingoLastToWin(List<int> inputDrawnNumbers, List<Board> inputBoards)
        {
            List<Board> cloneBoards = CloneBoardList(inputBoards);
            List<BoardWin> boardWin = new List<BoardWin>();

            // Draw all numbers and record all winning boards and winning numbers
            Console.Write("Play bingo last to win\n");
            for (int i = 0; i < inputDrawnNumbers.Count; i++)
            {
                int drawnNumber = inputDrawnNumbers[i];
                for (int j = 0; j < cloneBoards.Count; j++)
                {
                    Board board = cloneBoards[j];
                    for (int k = 0; k < board.Entries.Count; k++)
                    {
                        BoardEntry entry = board.Entries[k];
                        if (entry.Number == drawnNumber)
                        {
                            entry.Active = true;
                            int column = k % board.Size;
                            int row = k / board.Size;

                            bool wonColumn = board.CheckIfColumnHaveWon(column);
                            bool wonRow = board.CheckIfRowHaveWon(row);
                            if (wonColumn || wonRow)
                            {
                                boardWin.Add(new BoardWin(j, drawnNumber));
                            }
                        }
                    }
                }
            }
            if (boardWin.Count > 0)
            {
                // Reverse winning order
                boardWin.Reverse();

                // Check if board have already won before, if so check next
                BoardWin lastBoardWin = boardWin[0];
                for (int i = 0; i < boardWin.Count; i++)
                {
                    int count = 0;
                    for (int j = i + 1; j < boardWin.Count; j++)
                    {
                        if (boardWin[i].Index == boardWin[j].Index)
                        {
                            count++;
                        }
                    }
                    if (count == 0)
                    {
                        lastBoardWin = boardWin[i];
                        break;
                    }
                }

                bool won = false;
                int index = lastBoardWin.Index;
                int number = 0;
                Board board = new Board(inputBoards[index]);

                // Draw numbers until last winning board wins
                for (int i = 0; i < inputDrawnNumbers.Count && !won; i++)
                {
                    number = inputDrawnNumbers[i];
                    Console.Write("Number drawn: {0}\n", number);
                    for (int j = 0; j < board.Entries.Count; j++)
                    {
                        BoardEntry entry = board.Entries[j];
                        if (entry.Number == number)
                        {
                            entry.Active = true;
                            int column = j % board.Size;
                            int row = j / board.Size;

                            bool wonColumn = board.CheckIfColumnHaveWon(column);
                            bool wonRow = board.CheckIfRowHaveWon(row);
                            won = wonColumn || wonRow;
                        }
                    }
                }

                Console.Write("Last Winning board: {0}\n", index);
                Console.Write("Winning number: {0}\n", number);
                Console.Write("Score: {0}\n", board.Score(number));
                Console.Write(board + "\n\n");
            }
            else
            {
                Console.Write("No last winning boards :(\n");
            }
        }

        private static void PrintList<T>(List<T> input, string name, string separation)
        {
            Console.Write("Start of {0}[{1}] print\n", name, input.Count);
            if (0 < input.Count)
            {
                for (int i = 0; i < input.Count - 1; i++)
                {
                    Console.Write(input[i] + separation);
                }
                Console.Write(input[input.Count - 1] + "\n");
            }
            Console.Write("End of {0} print\n\n", name);
        }

        private static void Main(string[] args)
        {
            Console.Write("Advent of code 2021\n");
            Console.Write("Day 4: Giant Squid\n");
            Console.Write("Program by David Erikssen\n\n");

            const int boardSize = 5;

            List<int> drawnNumbers = InputDrawnNumbers();
            List<Board> boards = InputBoards(boardSize);

            PrintList(drawnNumbers, "drawn numbers", ",");
            PrintList(boards, "boards", "\n\n");

            PlayBingoFirstToWin(drawnNumbers, boards);
            PlayBingoLastToWin(drawnNumbers, boards);
        }
    }
}
