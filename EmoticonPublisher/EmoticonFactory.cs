namespace EmoticonPublisher
{
    public static class EmoticonFactory
    {
        public static string generateEmoticon(string emoticonName)
        {
            switch(emoticonName.ToLower())
            {
                case "koala":
                    return "ʕ•ᴥ•ʔ";
                default:
                    return "Error: Emoticon not found.";
            }

        }
    }
}