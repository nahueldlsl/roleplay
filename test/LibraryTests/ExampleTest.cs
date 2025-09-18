using Library;

namespace LibraryTests;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void CrearElfoTest(Elfos elfo)
    {
        Elfos Adam = new Elfos("Adam");
        Assert.Pass();
    }
}