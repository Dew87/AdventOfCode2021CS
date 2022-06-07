namespace Day4
{
    public class BoardEntry
    {
        public bool Active { get; set; }
        public int Number { get; set; }

        public BoardEntry(int number)
        {
            Active = false;
            Number = number;
        }

        public BoardEntry(BoardEntry boardEntry)
        {
            Active = boardEntry.Active;
            Number = boardEntry.Number;
        }
    }
}
