namespace IntroductionToAkka.Messages
{
    public class PlayMessage
    {
        public string Title { get; private set; }
        public string Username { get; private set; }

        public PlayMessage(string title, string username)
        {
            Title = title;
            Username = username;
        }
    }
}
