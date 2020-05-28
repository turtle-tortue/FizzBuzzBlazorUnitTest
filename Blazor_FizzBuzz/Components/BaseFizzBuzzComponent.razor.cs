namespace Blazor_FizzBuzz.Components
{
    using Microsoft.AspNetCore.Components;
    using Blazor_FizzBuzz.Data;

    public partial class BaseFizzBuzzComponent : ComponentBase
    {
        private int currentIteration = 1;
        private FizzBuzzEnum fizzBuzzEnum;
        private readonly int MAX_COUNT = 100;

        public bool ReachedIterationEnd()
        {
            return this.currentIteration > this.MAX_COUNT;
        }

        public void IncrementIterator()
        {
            SetIterator(this.currentIteration + 1);
        }

        public int GetCurrentIterator()
        {
            return this.currentIteration;
        }

        public void SetIterator(int value)
		{
            this.currentIteration = value;
            this.SetCurrentState();
		}

        public string GetStateString()
        {
            switch (this.fizzBuzzEnum)
            {
                case FizzBuzzEnum.BUZZ:
                    return this.BuzzString;
                case FizzBuzzEnum.FIZZ:
                    return this.FizzString;
                case FizzBuzzEnum.FIZZBUZZ:
                    return string.Format("{0}{1}",
                        this.FizzString,
                        this.BuzzString);
                case FizzBuzzEnum.NUMBER:
                default:
                    return this.NumberString;
            }
        }

        private void SetCurrentState()
        {
            var iteration = this.currentIteration;

            if (this.IsMultipleOf15(iteration))
            {
                this.fizzBuzzEnum = FizzBuzzEnum.FIZZBUZZ;
            }
            else if (this.IsMultipleOf3(iteration))
            {
                this.fizzBuzzEnum = FizzBuzzEnum.FIZZ;
            }
            else if (this.IsMultipleOf5(iteration))
            {
                this.fizzBuzzEnum = FizzBuzzEnum.BUZZ;
            }
            else
            {
                this.fizzBuzzEnum = FizzBuzzEnum.NUMBER;
            }
        }

        public int GetMaximumNumberOfIterations()
        {
            return this.MAX_COUNT;
        }

        public string TextToPrint()
        {
            switch (this.fizzBuzzEnum)
            {
                case FizzBuzzEnum.BUZZ:
                    return this.BuzzString;
                case FizzBuzzEnum.FIZZ:
                    return this.FizzString;
                case FizzBuzzEnum.FIZZBUZZ:
                    return string.Format("{0}{1}",
                        this.FizzString,
                        this.BuzzString);
                case FizzBuzzEnum.NUMBER:
                default:
                    return this.currentIteration.ToString();
            }
        }

        private bool IsMultipleOf3(int number)
        {
            return number % 3 == 0;
        }

        private bool IsMultipleOf5(int number)
        {
            return number % 5 == 0;
        }

        private bool IsMultipleOf15(int number)
        {
            return number % 15 == 0;
        }

        protected readonly string BuzzString = "Buzz";
        protected readonly string FizzString = "Fizz";
        protected string FizzBuzz => string.Format("{0}{1}", this.BuzzString, this.FizzString);
        protected readonly string NumberString = "Number";
    }
}

