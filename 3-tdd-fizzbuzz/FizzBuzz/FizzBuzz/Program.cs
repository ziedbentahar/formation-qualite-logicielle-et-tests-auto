

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
           /* Write a program that prints the numbers from 1 to 100. 
            * But for multiples of three print “Fizz” instead of the number and for the multiples of five print “Buzz”. 
            * For numbers which are multiples of both three and five print “FizzBuzz”. */

        }
    }

    public class FizzBuzzService
    {
        public string GetValue(int number)
        {
            if (number % 3 == 0 && number % 5 == 0)
                return "fizzBuzz";
            if (number % 3 == 0)
                return "fizz";
            if (number % 5 == 0)
                return "buzz";

            return number.ToString();

        }
    }
}
