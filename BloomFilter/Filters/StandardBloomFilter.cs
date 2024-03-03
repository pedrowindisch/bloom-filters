using System.Collections;
using BloomFilter.Models;

namespace BloomFilter.Filters;

public class StandardBloomFilter
{
    private readonly BitArray _array;
    private readonly HashMethod<string> _hashMethod;
    private readonly int _bitsPerElement;

    public int Size => _array.Length;

    public StandardBloomFilter(int size) : this(size, null) { }
    public StandardBloomFilter(int size, HashMethod<string>? hashMethod) : this(size, 1, hashMethod) { }
    public StandardBloomFilter(int size, int bitsPerElement) : this(size, bitsPerElement, null) { }

    public StandardBloomFilter(int size, int bitsPerElement, HashMethod<string>? hashMethod) 
    {
        if (size < 1) throw new ArgumentOutOfRangeException("size", null, "O parâmetro size precisa ser um número inteiro positivo.");
        if (bitsPerElement < 1) throw new ArgumentOutOfRangeException("bitsPerElement", null, "O parâmetro de bits por elemento precisa ser um número inteiro positivo.");

        _array = new(size);
        _bitsPerElement = bitsPerElement;
        _hashMethod = hashMethod ?? StringHash;
    }

    private int StringHash(string value)
    {
        return value.GetHashCode();
    }

    private HashSet<int> HashValues(string value)
    {
        HashSet<int> bits = new();
        for (var i = 0; i < _bitsPerElement; i++)
            bits.Add(Math.Abs(value.GetHashCode() + (i * _hashMethod(value))) % Size);

        return bits;
    }

    public void Add(string value)
    {
        var bitsToToggle = HashValues(value);
        foreach(var bit in bitsToToggle)
            _array.Set(bit, true);
    }

    public bool Contains(string value)
    {
        var bitsToToggle = HashValues(value);

        return bitsToToggle.All(_array.Get);
    }
}