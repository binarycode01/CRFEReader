using CR.XML.Reader.BL;
using Xunit;

namespace CR.XML.Reader.Test;

public class TextCleanerTest
{
    [Fact]
    public void Fix_Excape_Characters()
    {
        string originalText = "Hola \r\nMundo ";

        var converted = TextCleaner.FixEscapeCaracter(originalText);

        Assert.Equal("Hola Mundo", converted);
    }
}
