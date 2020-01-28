namespace EmoticonPublisher
{
    public static class EmoticonFactory
    {
        public static string createEmoticon(string emoticonName)
        {
            switch(emoticonName.ToLower())
            {
                case "koala":
                    return Emoticons.Koala;

                default:
                    return Commands.Unrecognized;
            }

            
        }
    }
}