using System;

namespace CastleWindsorIoC
{
    public class Logger
    {
        private readonly IAnimal _animal;

        public Logger(IAnimal animal)
        {
            _animal = animal;
        }

        public void DisplayMessage()
        {
            Console.WriteLine(_animal.Name);
        }
    }
}