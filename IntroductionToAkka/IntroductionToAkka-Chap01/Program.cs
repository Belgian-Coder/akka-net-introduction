using Akka.Actor;
using IntroductionToAkka.Helpers;
using System;

namespace IntroductionToAkka
{
    class Program
    {
        private static ActorSystem StreamingActorSystem;

        static void Main(string[] args)
        {
            // Create the actor system with the name StreamingActorSystem
            StreamingActorSystem = ActorSystem.Create(nameof(StreamingActorSystem));
            ConsoleHelper.WriteColoredLine("Actor system created.");

            // Terminate the actor system
            (StreamingActorSystem.Terminate()).GetAwaiter().GetResult();
            Console.WriteLine("Actor system terminated");
            Console.ReadLine();
        }
    }
}
