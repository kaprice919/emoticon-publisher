using System.Collections.Generic;

namespace EmoticonPublisher
{
    public static class EmoticonFactory
    {
        private static readonly Dictionary<string, string> Emoticons
            = new Dictionary<string, string>
        {
            { "ameno",        "༼ つ ◕_◕ ༽つ"   },
            { "cat",          "(=^ェ^=)"      },
            { "confused",     "¯\\(°_o)/¯"    },
            { "stare",        "ಠ_ಠ"           },
            { "koala",        "ʕ•ᴥ•ʔ"         },
            { "lenny",        "( ͡° ͜ʖ ͡°)"      },
            { "tableflip",    "(╯°□°）╯︵ ┻━┻" }
        };
        
        public static string createEmoticon(string emoticonName)
        {
            return Emoticons.GetValueOrDefault(emoticonName.ToLower().Trim(), "Command Not Recognized");
        }
    }
}