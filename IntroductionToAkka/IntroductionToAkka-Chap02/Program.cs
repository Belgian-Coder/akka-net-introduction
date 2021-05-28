using Akka.Actor;
using IntroductionToAkka.Actors;
using IntroductionToAkka.Helpers;
using IntroductionToAkka.Messages;
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

            // Create the playbackActor
            Props playbackActorProps = Props.Create<PlaybackActor>();
            IActorRef playbackActorRef = StreamingActorSystem.ActorOf(playbackActorProps, nameof(PlaybackActor));

            var user = "Timmy";
            var movie1 = "North Park - The Movie";
            var movie2 = "Eastworld";

            // Start playing movie1
            ConsoleHelper.WriteColoredLine($"Sending PlayMessage for {movie1}", ConsoleColor.Cyan);
            playbackActorRef.Tell(new PlayMessage(movie1, user));
            Console.ReadLine();

            // Try playing movie2 while movie1 is playing
            ConsoleHelper.WriteColoredLine($"Sending PlayMessage for {movie2}", ConsoleColor.Cyan);
            playbackActorRef.Tell(new PlayMessage(movie2, user));
            Console.ReadLine();

            // Stop the current movie
            ConsoleHelper.WriteColoredLine($"Sending StopMessage for {user}", ConsoleColor.Red);
            playbackActorRef.Tell(new StopMessage(user));
            Console.ReadLine();

            // Try stopping the movie when no movie is playing
            ConsoleHelper.WriteColoredLine($"Sending StopMessage for {user}", ConsoleColor.Red);
            playbackActorRef.Tell(new StopMessage(user));
            Console.ReadLine();

            // Start playing movie1 again
            ConsoleHelper.WriteColoredLine($"Sending PlayMessage for {movie1}", ConsoleColor.Cyan);
            playbackActorRef.Tell(new PlayMessage(movie1, user));
            Console.ReadLine();

            // Kill the playbackActor
            ConsoleHelper.WriteColoredLine("Killing the UserActor", ConsoleColor.Cyan);
            playbackActorRef.Tell(PoisonPill.Instance);
            Console.ReadLine();

            // Try sending message after killing actor
            ConsoleHelper.WriteColoredLine($"Sending PlayMessage for {movie1}", ConsoleColor.Cyan);
            playbackActorRef.Tell(new PlayMessage(movie1, user));
            Console.ReadLine();

            // Terminate the actor system
            (StreamingActorSystem.Terminate()).GetAwaiter().GetResult();
            Console.WriteLine("Actor system terminated");
            Console.ReadLine();
        }
    }
}
