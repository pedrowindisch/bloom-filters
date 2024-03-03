using BloomFilter.Filters;
using Tests.Lib;

namespace Tests;

public class Tests
{
    [Test]
    public void LookupElements(
        [Values("Blumenau", "Itajaí", "Florianópolis", "Joinville", "São José", "Criciúma", "Chapecó")]
        string city
    )
    {
        var filter = new StandardBloomFilter(10);

        filter.Add(city);

        Assert.That(filter.Contains(city), Is.True);
    }

    [Test]
    public void MissingElements()
    {
        var filter = new StandardBloomFilter(10);

        Assert.That(filter.Contains("Blumenau"), Is.False);
    }

    [Test]
    public void WithCustomHasher()
    {
        var filter = new StandardBloomFilter(10, CustomHasher.SimpleHasher);

        filter.Add("Blumenau");

        Assert.That(filter.Contains("Blumenau"), Is.True);
    }

    [Test]
    public void InvalidSizes(
        [Values(-1, 0)]
        int invalidSize
    )
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new StandardBloomFilter(invalidSize)
        );
    }

    [Test]
    public void InvalidBitsPerElement(
        [Values(-1, 0)]
        int invalidBitsPerElement
    )
    {
        Assert.Throws<ArgumentOutOfRangeException>(
            () => new StandardBloomFilter(10, invalidBitsPerElement)
        );
    }
}