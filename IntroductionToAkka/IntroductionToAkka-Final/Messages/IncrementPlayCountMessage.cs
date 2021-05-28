namespace IntroductionToAkka.Messages
{
    public class IncrementPlayCountMessage
    {
        public string Title { get; private set; }

        public IncrementPlayCountMessage(string title)
        {
            Title = title;
        }
    }
}
