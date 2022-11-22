public class liczbyparzyste
{
    [Fact]
    public void czypierwszaparzysta()
    {

        string[] liczby = new string[] { "2", "3", "5", "1", "8" };
        Assert.Equal("2", liczby[0]);

    }

}