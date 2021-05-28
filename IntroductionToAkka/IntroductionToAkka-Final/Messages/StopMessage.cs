namespace IntroductionToAkka.Messages
{
    public class StopMessage
    {
        public string Username { get; private set; }

        public StopMessage(string username)
        {
            Username = username;
        }
    }
}
