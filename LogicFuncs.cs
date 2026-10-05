namespace Assignment5_3 {
    internal class LogicFuncs {

        public static int OpenSpots(int[] flowers) {

            int[] plots = (int[])flowers.Clone();
            int planted = 0;

            for (int spot = 0; spot < plots.Length; spot++) {

                if (plots[spot] != 0)
                    continue;

                bool leftOpen = spot == 0 || plots[spot - 1] == 0;
                bool rightOpen = spot == plots.Length - 1 || plots[spot + 1] == 0;

                if (leftOpen && rightOpen) {
                    plots[spot] = 1;
                    planted++;
                }
            }

            return planted;

        }

        public static bool CanAddFlowers(int[] flowers, int wanted) {

            return OpenSpots(flowers) >= wanted;

        }

        public static int WaysUpStairs(int steps) {

            if (steps <= 2)
                return steps;

            int twoBack = 1;
            int oneBack = 2;

            for (int step = 3; step <= steps; step++) {
                int ways = twoBack + oneBack;
                twoBack = oneBack;
                oneBack = ways;
            }

            return oneBack;

        }
    }
}
