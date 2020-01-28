using System.Collections.Generic;

namespace EmoticonPublisher
{
    public static class EmoticonFactory
    {
        private static readonly Dictionary<string, string> Emoticons
            = new Dictionary<string, string>
        {
            { "koala", "ʕ•ᴥ•ʔ" }
        };
        
        public static string createEmoticon(string emoticonName)
        {
            
            return Emoticons.GetValueOrDefault(emoticonName.ToLower(), "Command Not Recognized");
        }
    }
}