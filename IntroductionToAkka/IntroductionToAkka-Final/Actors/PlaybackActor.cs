using Akka.Actor;
using IntroductionToAkka.Helpers;
using IntroductionToAkka.Messages;
using System;

namespace IntroductionToAkka.Actors
{
    public class PlaybackActor : UntypedActor
    {
        private string _currentlyStreaming;

        public PlaybackActor()
        {

        }

        protected override void OnReceive(object message)
        {
            switch (message)
            {
                case PlayMessage m:
                    Play(m);
                    break;
                case StopMessage m:
                    Stop(m);
                    break;
                default:
                    Unhandled(message);
                    break;
            }
        }

        private void Play(PlayMessage item)
        {
            if (String.IsNullOrWhiteSpace(_currentlyStreaming))
            {
                ConsoleHelper.WriteColoredLine($"PlayMessage received, playing movie: {item.Title}", ConsoleColor.DarkGreen);
                this._currentlyStreaming = item.Title;

                Context.ActorSelection("/user/CounterActor")
                    .Tell(new IncrementPlayCountMessage(item.Title));
            }
            else
            {
                ConsoleHelper.WriteColoredLine($"ERROR: cannot start playing movie while another is playing", ConsoleColor.DarkGreen);
            }
        }


        private void Stop(StopMessage item)
        {
            if (String.IsNullOrWhiteSpace(_currentlyStreaming))
            {
                ConsoleHelper.WriteColoredLine($"ERROR: there was no movie playing", ConsoleColor.DarkGreen);
            }
            else
            {
                ConsoleHelper.WriteColoredLine($"StopMessage received, stopping movie", ConsoleColor.DarkGreen);
                this._currentlyStreaming = String.Empty;
            }
        }
    }
}
