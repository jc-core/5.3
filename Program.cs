namespace Assignment5_3 {
    internal class Program {

        static void Main(string[] args) {

            Console.WriteLine("Select an option:");

            while (true) {

                Console.WriteLine();
                Console.WriteLine("  1 - Plant Flowers");
                Console.WriteLine("  2 - Ways Up Stairs");
                Console.WriteLine("  x - Quit");

                var choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                switch (choice) {
                    case '1':
                        PlantFlowers();
                        break;
                    case '2':
                        WaysUpStairs();
                        break;
                    case 'x':
                        return;
                    default:
                        Console.WriteLine("That is not one of the options, please select something from the list.");
                        continue;
                }

                if (EndPrompt())
                    return;

            }

        }

        static void PlantFlowers() {

            Console.WriteLine();
            Console.WriteLine("1 is a planted plot, 0 is an open one. No two flowers can sit side by side.");

            int[] flowers = ReadFlowers();
            int wanted = ReadFlowerCount();

            Console.WriteLine($"The row has room for {LogicFuncs.OpenSpots(flowers)} more.");
            Console.WriteLine(LogicFuncs.CanAddFlowers(flowers, wanted) ? $"You can plant {wanted}." : $"You cannot plant {wanted}.");

        }

        static void WaysUpStairs() {

            Console.WriteLine();
            Console.WriteLine("Steps are taken one or two at a time. Every different order counts as its own way up.");

            int steps = ReadSteps();

            Console.WriteLine($"There are {LogicFuncs.WaysUpStairs(steps)} ways to climb {steps} steps.");

        }

        static bool EndPrompt() {

            Console.WriteLine();
            Console.Write("Press enter to go back to the menu, or 'x' to quit: ");

            var choice = Console.ReadKey().KeyChar;
            Console.WriteLine();

            return choice == 'x';

        }

        static int ReadFlowerCount() {

            while (true) {

                Console.Write("How many flowers to plant: ");

                if (int.TryParse(Console.ReadLine(), out int value) && value >= 1)
                    return value;

                Console.WriteLine("Must plant at least one flower, try again.");

            }

        }

        static int ReadSteps() {

            while (true) {

                Console.Write("Number of steps: ");

                if (int.TryParse(Console.ReadLine(), out int value) && value >= 1 && value <= 45)
                    return value;

                Console.WriteLine("Whole numbers from 1 to 45 only, try again.");

            }

        }

        static int[] ReadFlowers() {

            while (true) {

                Console.Write("Row of 0s and 1s, separated by spaces: ");
                string[] plotInputs = (Console.ReadLine() ?? "").Split(' ', StringSplitOptions.RemoveEmptyEntries);

                List<int> parsedPlots = new();

                foreach (string plotInput in plotInputs) {
                    if (int.TryParse(plotInput, out int value) && (value == 0 || value == 1))
                        parsedPlots.Add(value);
                }

                if (parsedPlots.Count == 0 || parsedPlots.Count != plotInputs.Length) {
                    Console.WriteLine("Need at least one plot, and only 0s and 1s.");
                    continue;
                }

                if (AlreadyTouching(parsedPlots)) {
                    Console.WriteLine("Two of those flowers are already side by side, try again.");
                    continue;
                }

                return parsedPlots.ToArray();

            }

        }

        static bool AlreadyTouching(List<int> plots) {

            for (int spot = 1; spot < plots.Count; spot++) {
                if (plots[spot] == 1 && plots[spot - 1] == 1)
                    return true;
            }

            return false;

        }
    }
}
