namespace Day2
{
    public class Command
    {
        public string Type { get; set; }
        public int Value { get; set; }

        public Command(string type, int value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return Type + ' ' + Value;
        }
    }
}
