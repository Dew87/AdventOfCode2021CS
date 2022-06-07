namespace Day1
{
    public class Program
    {
        private static List<int> InputScan()
        {
            List<int> output = new List<int>();
            bool valid = true;
            Console.Write("Start of scan input (Invalid input to end)\n");
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
                            output.Add(number);
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
            Console.Write("End of scan input\n\n");
            return output;
        }

        private static int NumberOfIncreasesInList(List<int> input)
        {
            int output = 0;
            for (int i = 1; i < input.Count; i++)
            {
                if (input[i - 1] < input[i])
                {
                    output++;
                }
            }
            return output;
        }

        private static List<int> SumsOfNumberInList(List<int> input, int number)
        {
            List<int> output = new List<int>();
            if (number <= input.Count)
            {
                for (int i = number - 1; i < input.Count; i++)
                {
                    int sum = 0;
                    for (int j = i + 1 - number; j <= i; j++)
                    {
                        sum += input[j];
                    }
                    output.Add(sum);
                }
            }
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
            Console.Write("Day 1: Sonar Sweep\n");
            Console.Write("Program by David Erikssen\n\n");

            int number = 3;

            List<int> scan = InputScan();
            List<int> scanSums = SumsOfNumberInList(scan, number); ;

            PrintList(scan, "scan", "\n");
            PrintList(scanSums, "scan sums", "\n");

            int scanIncreases = NumberOfIncreasesInList(scan);
            int scanSumsIncreases = NumberOfIncreasesInList(scanSums);

            Console.Write("Scan increases: {0}\n", scanIncreases);
            Console.Write("Scan sums of {1} increases: {0}\n", scanSumsIncreases, number);
        }
    }
}
