// See https://aka.ms/new-console-template for more information
using UnitTesting;

Console.WriteLine("Fizzbuzz !");
var objFizzBuzz = new FizzBuzz();

Console.WriteLine("Enter a number");
if (!int.TryParse(Console.ReadLine(), out int num))
{
    Console.WriteLine("Invalid value entered. Enter the integer value only.");
}
else
{
    Console.WriteLine($"Fizzbuzz result => {objFizzBuzz.GetFizzBuzzResult(num)}");
}
