namespace Day4
{
    public class Board
    {
        public List<BoardEntry> Entries { get; set; }
        public int Size { get; set; }

        public Board(List<BoardEntry> entries, int size)
        {
            Entries = entries;
            Size = size;
        }

        public Board(Board board)
        {
            List<BoardEntry> entries = new List<BoardEntry>();
            foreach (BoardEntry entry in board.Entries)
            {
                entries.Add(new BoardEntry(entry));
            }
            Entries = entries;
            Size = board.Size;
        }

        public bool CheckIfColumnHaveWon(int column)
        {
            int count = 0;
            for (int i = 0; i < Size; i++)
            {
                if (Entries[(i * Size) + column].Active)
                {
                    count++;
                }
            }
            return count == Size;
        }

        public bool CheckIfRowHaveWon(int row)
        {
            int count = 0;
            for (int i = 0; i < Size; i++)
            {
                if (Entries[(row * Size) + i].Active)
                {
                    count++;
                }
            }
            return count == Size;
        }

        public int Score(int number)
        {
            int sum = 0;
            for (int i = 0; i < Entries.Count; i++)
            {
                if (!Entries[i].Active)
                {
                    sum += Entries[i].Number;
                }
            }
            return sum * number;
        }

        public override string ToString()
        {
            string output = "";
            if (0 < Size)
            {
                for (int i = 0; i < Size - 1; i++)
                {
                    int rowIndex = i * Size;
                    for (int j = 0; j < Size - 1; j++)
                    {
                        output += Entries[rowIndex + j].Number + " ";
                    }
                    output += Entries[rowIndex + Size - 1].Number + "\n";
                }
                int lastRowIndex = Size * (Size - 1);
                for (int j = 0; j < Size - 1; j++)
                {
                    output += Entries[lastRowIndex + j].Number + " ";
                }
                output += Entries[(Size * Size) - 1].Number;
            }
            return output;
        }
    }
}
