namespace Day3
{
    public class Program
    {
        private static int CO2ScrubberRating(List<string> input)
        {
            if (0 < input.Count)
            {
                List<string> inputCopy = input;
                int numberOfBits = input[0].Length;
                for (int i = 0; i < numberOfBits; i++)
                {
                    int count = CountNumberOfCharOnIndexInList(inputCopy, '0', i);
                    char c = inputCopy.Count - count < count ? '1' : '0';

                    List<string> inputNext = new List<string>();
                    foreach (string s in inputCopy)
                    {
                        if (s[i] == c)
                        {
                            inputNext.Add(s);
                        }
                    }
                    if (inputNext.Count == 1)
                    {
                        try
                        {
                            return Convert.ToInt32(inputNext[0], 2);
                        }
                        catch (Exception)
                        {
                            return 0;
                        }
                    }
                    inputCopy = inputNext;
                }
            }
            return 0;
        }

        private static int CountNumberOfCharOnIndexInList(List<string> input, char c, int index)
        {
            int output = 0;
            if (0 < input.Count && index < input[0].Length)
            {
                foreach (string s in input)
                {
                    if (s[index] == c)
                    {
                        output++;
                    }
                }
            }
            return output;
        }

        private static int EpsilonRate(List<string> input)
        {
            int output = 0;
            if (0 < input.Count)
            {
                int numberOfBits = input[0].Length;
                for (int i = 0; i < numberOfBits; i++)
                {
                    int count = CountNumberOfCharOnIndexInList(input, '1', i);
                    if (count < input.Count - count)
                    {
                        output += 1 << (numberOfBits - 1 - i);
                    }
                }
            }
            return output;
        }

        private static int GammaRate(List<string> input)
        {
            int output = 0;
            if (0 < input.Count)
            {
                int numberOfBits = input[0].Length;
                for (int i = 0; i < numberOfBits; i++)
                {
                    int count = CountNumberOfCharOnIndexInList(input, '1', i);
                    if (input.Count - count < count)
                    {
                        output += 1 << (numberOfBits - 1 - i);
                    }
                }
            }
            return output;
        }

        private static List<string> InputBinaryCode()
        {
            List<string> output = new List<string>();
            bool valid = true;
            int length = -1;
            Console.Write("Start of binary code input (Invalid input to end)\n");
            while (valid)
            {
                string? input = Console.ReadLine();
                if (input != null)
                {
                    try
                    {
                        Convert.ToInt32(input, 2);
                        if (length == -1)
                        {
                            length = input.Length;
                            output.Add(input);
                        }
                        else if (input.Length == length)
                        {
                            output.Add(input);
                        }
                        else
                        {
                            valid = false;
                        }
                    }
                    catch (Exception)
                    {
                        valid = false;
                    }
                }
            }
            Console.Write("End of binary code input\n\n");
            return output;
        }

        private static int OxygenGeneratorRating(List<string> input)
        {
            if (0 < input.Count)
            {
                List<string> inputCopy = input;
                int numberOfBits = input[0].Length;
                for (int i = 0; i < numberOfBits; i++)
                {
                    int count = CountNumberOfCharOnIndexInList(inputCopy, '1', i);
                    char c = count < inputCopy.Count - count ? '0' : '1';

                    List<string> inputNext = new List<string>();
                    foreach (string s in inputCopy)
                    {
                        if (s[i] == c)
                        {
                            inputNext.Add(s);
                        }
                    }
                    if (inputNext.Count == 1)
                    {
                        try
                        {
                            return Convert.ToInt32(inputNext[0], 2);
                        }
                        catch (Exception)
                        {
                            return 0;
                        }
                    }
                    inputCopy = inputNext;
                }
            }
            return 0;
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
            Console.Write("Day 3: Binary Diagnostic\n");
            Console.Write("Program by David Erikssen\n\n");

            List<string> code = InputBinaryCode();
            PrintList(code, "binary code", "\n");

            int gammaRate = GammaRate(code);
            int epsilonRate = EpsilonRate(code);
            int powerConsumption = epsilonRate * gammaRate;

            int oxygenGeneratorRating = OxygenGeneratorRating(code);
            int co2ScrubberRating = CO2ScrubberRating(code);
            int lifeSupportRating = oxygenGeneratorRating * co2ScrubberRating;

            Console.Write("Gamma rate: {0}\n", gammaRate);
            Console.Write("Epsilon rate: {0}\n", epsilonRate);
            Console.Write("Power consumption: {0}\n\n", powerConsumption);

            Console.Write("Oxygen generator rating: {0}\n", oxygenGeneratorRating);
            Console.Write("CO2 scrubber rating: {0}\n", co2ScrubberRating);
            Console.Write("Life support rating: {0}\n", lifeSupportRating);
        }
    }
}
