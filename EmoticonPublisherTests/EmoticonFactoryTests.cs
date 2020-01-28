using Xunit;
using FluentAssertions;
using EmoticonPublisher;

namespace EmoticonPublisherTests
{
    public class EmoticonFactoryTests
    {
        [Fact]
        public void TestEmoticonFactoryReturnsKoalaTextWhenGivenKoalaName()
        {
            string emoticonName = "Koala";
            string expectedEmoticonText = "ʕ•ᴥ•ʔ";

            string actualEmoticonText = EmoticonFactory.createEmoticon(emoticonName);
            actualEmoticonText.Should().BeEquivalentTo(expectedEmoticonText);
        }

        [Fact]
        public void TestEmoticonFactoryReturnsUnrecognizedTextWhenGivenBadEmoticon()
        {
            string commandName = "Bad Command";
            string expectedText = "Command Not Recognized";

            string actualText = EmoticonFactory.createEmoticon(commandName);
            actualText.Should().BeEquivalentTo(expectedText);
        }
    }
}
