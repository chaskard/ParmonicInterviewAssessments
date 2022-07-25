namespace UnitTesting
{
    public class FizzBuzz
    {
        public object GetFizzBuzzResult(int input)
        {
            if (input < 1)
                throw new IndexOutOfRangeException();
            if (input % 15 == 0)
                return "FizzBuzz";
            if (input % 3 == 0)
                return "Fizz";
            if (input % 5 == 0)
                return "Buzz";
            return input;
        }
    }
}
