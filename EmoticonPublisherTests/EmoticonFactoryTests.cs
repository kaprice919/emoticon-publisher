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
    }
}
