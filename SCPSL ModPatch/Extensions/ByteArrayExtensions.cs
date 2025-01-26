using System;
/// <summary>
/// Simple byte sequence finder. The code can be optimized a little bit like embedding the byte comparison in the for loop. Not sure if the .net compiler does this optimization.
/// Probably can be faster with some search algorithm but I just needed a small and readable fast enough version
/// </summary>
static class ByteArrayExtensions
{
    public static long LastIndexOf(this byte[] data, byte[] pattern)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));
        if (pattern == null) throw new ArgumentNullException(nameof(pattern));
        if (pattern.LongLength > data.LongLength) return -1;

        var cycles = data.LongLength - pattern.LongLength + 1;
        long patternIndex;
        for (var dataIndex = cycles; dataIndex > 0; dataIndex--)
        {
            if (data[dataIndex] != pattern[0]) continue;
            for (patternIndex = pattern.Length - 1; patternIndex >= 1; patternIndex--) if (data[dataIndex + patternIndex] != pattern[patternIndex]) break;
            if (patternIndex == 0) return dataIndex;
        }
        return -1;
    }
    public static long IndexOf(this byte[] data, byte[] pattern, long startIndex)
    {
        if (data == null) throw new ArgumentNullException(nameof(data));
        if (pattern == null) throw new ArgumentNullException(nameof(pattern));
        if (pattern.LongLength > data.LongLength) return -1;

        var cycles = data.LongLength - pattern.LongLength + 1;
        long patternIndex;
        for (var dataIndex = startIndex; dataIndex < cycles; dataIndex++)
        {
            if (data[dataIndex] != pattern[0]) continue;
            for (patternIndex = pattern.Length - 1; patternIndex >= 1; patternIndex--) if (data[dataIndex + patternIndex] != pattern[patternIndex]) break;
            if (patternIndex == 0) return dataIndex;
        }
        return -1;
    }
}