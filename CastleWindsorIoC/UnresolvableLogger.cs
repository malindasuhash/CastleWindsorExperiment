using System;

namespace CastleWindsorIoC
{
    public class UnresolvableLogger : ILogger
    {
        private readonly IAnimal _animal;

        public UnresolvableLogger(IAnimal animal)
        {
            _animal = animal;
        }

        public void DisplayMessage()
        {
            Console.WriteLine(_animal.Name);
        }
    }
}