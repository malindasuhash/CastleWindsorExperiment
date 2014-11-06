using System;

namespace CastleWindsorIoC
{
    public interface ILogger
    {
        void DisplayMessage();
    }

    public class Logger : ILogger
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