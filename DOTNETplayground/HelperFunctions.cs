namespace UtilTools
{
    public static class HelperFunctions
    {
        public static int GetUserInt()
        {
            int input;
            if (!int.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a valid input. \n");
                return 0;
            }

            return input;
        }

        public static double GetUserDouble()
        {
            double input;
            if (!double.TryParse(Console.ReadLine(), out input))
            {
                Console.WriteLine("Please enter a valid input. \n");
                return 0;
            }

            return input;
        }

        // This method is to check to make sure the user inputs something (rather than them entering nothing)
        public static string GetUserString()
        {
            string input = Console.ReadLine();
            while (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Please input some characters. \n");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}