using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz.Tests
{
    public class FizzBuzzTests
    {
        [Test]
        public void Should_return_a_number_as_string_when_number_is_not_a_multiple_of_three()
        {
            //Arrange
            var fizzBuzzService = new FizzBuzzService();

            //Act
            var result = fizzBuzzService.GetValue(2);

            //Assert
            Assert.True(result == "2");


        }

        [Test]
        public void Should_return_fizz_when_number_is_a_multiple_of_three()
        {
            //Arrange
            var fizzBuzzService = new FizzBuzzService();

            //Act
            var result = fizzBuzzService.GetValue(3);

            //Assert
            Assert.True(result == "fizz");
            
        }
        

        [Test, TestCaseSource(typeof(FizzBuzzTests), nameof(OnlyAllMuliplesOfFives))]
        public void Should_return_buzz_when_number_is_a_multiple_of_five_only(int number)
        {
            //Arrange
            var fizzBuzzService = new FizzBuzzService();

            //Act
            var result = fizzBuzzService.GetValue(number);

            //Assert
            Assert.True(result == "buzz");
        }

        [Test, TestCaseSource(typeof(FizzBuzzTests), nameof(OnlyAllMuliplesOfThree))]
        public void Should_return_fizz_when_number_is_a_multiple_of_three_only(int number)
        {
            //Arrange
            var fizzBuzzService = new FizzBuzzService();

            //Act
            var result = fizzBuzzService.GetValue(number);

            //Assert
            Assert.True(result == "fizz");
        }



        public static IEnumerable OnlyAllMuliplesOfFives
        {
            get
            {
                return Enumerable.Range(1, 100).Where(item => item % 5 == 0 && item % 3 != 0);
            }
        }

        public static IEnumerable OnlyAllMuliplesOfThree
        {
            get
            {
                return Enumerable.Range(1, 100).Where(item => item % 3 == 0 && item % 5 != 0);
            }
        }
    }
}
