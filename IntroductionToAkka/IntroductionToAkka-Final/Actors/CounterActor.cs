using Akka.Actor;
using IntroductionToAkka.Helpers;
using IntroductionToAkka.Messages;
using System;
using System.Collections.Generic;

namespace IntroductionToAkka.Actors
{
    public class CounterActor : ReceiveActor
    {
        private readonly Dictionary<string, int> _playCounts;

        public CounterActor()
        {
            _playCounts = new Dictionary<string, int>();

            Receive<IncrementPlayCountMessage>(msg => HandleIncrementMessage(msg));
        }

        public void HandleIncrementMessage(IncrementPlayCountMessage msg)
        {
            if(_playCounts.ContainsKey(msg.Title))
            {
                _playCounts[msg.Title]++;
            }
            else
            {
                _playCounts.Add(msg.Title, 1);
            }

            ConsoleHelper.WriteColoredLine($"Movie {msg.Title} was played {_playCounts[msg.Title]} time(s)", ConsoleColor.Gray);
        }
    }
}
