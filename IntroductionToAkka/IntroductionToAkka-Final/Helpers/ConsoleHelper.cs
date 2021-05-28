using System;

namespace IntroductionToAkka.Helpers
{
    public class ConsoleHelper
    {
        public static void WriteColoredLine(string message, ConsoleColor color = ConsoleColor.White)
        {
            // Save the previous color
            var previousColor = Console.ForegroundColor;
            // Change the current console text color
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            // Reset the color back to the previous
            Console.ForegroundColor = previousColor;
        }
    }
}
