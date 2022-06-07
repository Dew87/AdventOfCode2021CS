namespace Day2
{
    public class Program
    {
        private static Vector2I ExecuteCommandsNew(List<Command> input)
        {
            Vector2I output = new Vector2I();
            int aim = 0;
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Type == "forward")
                {
                    output += new Vector2I(input[i].Value, input[i].Value * aim);
                }
                else if (input[i].Type == "down")
                {
                    aim += input[i].Value;
                }
                else if (input[i].Type == "up")
                {
                    aim -= input[i].Value; ;
                }
            }
            return output;
        }

        private static Vector2I ExecuteCommandsOld(List<Command> input)
        {
            Vector2I output = new Vector2I();
            for (int i = 0; i < input.Count; i++)
            {
                if (input[i].Type == "forward")
                {
                    output += new Vector2I(input[i].Value, 0);
                }
                else if (input[i].Type == "down")
                {
                    output += new Vector2I(0, input[i].Value);
                }
                else if (input[i].Type == "up")
                {
                    output += new Vector2I(0, -input[i].Value);
                }
            }
            return output;
        }

        private static List<Command> InputCommands()
        {
            List<Command> output = new List<Command>();
            bool valid = true;
            Console.Write("Start of commands input (forward X down X up X Invalid input to end)\n");
            while (valid)
            {
                string? input = Console.ReadLine();
                if (input != null)
                {
                    string[] inputSplit = input.Split(' ', System.StringSplitOptions.RemoveEmptyEntries);
                    if (inputSplit.Count() == 2)
                    {
                        string type = inputSplit[0];
                        if ((type == "forward" || type == "down" || type == "up") && Int32.TryParse(inputSplit[1], out int value))
                        {
                            output.Add(new Command(type, value));
                            continue;
                        }
                    }
                }
                valid = false;
            }
            Console.Write("End of command input\n\n");
            return output;
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
            Console.Write("Day 2: Dive!\n");
            Console.Write("Program by David Erikssen\n\n");

            List<Command> commands = InputCommands();
            PrintList(commands, "commands", "\n");

            Vector2I positionOld = ExecuteCommandsOld(commands);
            Vector2I positionNew = ExecuteCommandsNew(commands);

            int multiplyOld = positionOld.X * positionOld.Y;
            int multiplyNew = positionNew.X * positionNew.Y;

            Console.Write("Position old steering {0}\n", positionOld);
            Console.Write("Multiply old steering: {0}\n\n", multiplyOld);

            Console.Write("Position new steering {0}\n", positionNew);
            Console.Write("Multiply new steering: {0}\n", multiplyNew);
        }
    }
}
