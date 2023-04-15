
using System;
using pkg;
using Xunit;

namespace tests;

public class ReadOnySpanExtensions
{
    [Fact]
    public void RemoveTest()
    {
        // Given
        string str = "12345";
        ReadOnlySpan<char> input = str.AsSpan();
    
        // When
        var output = input.Remove(2,1);
    
        // Then
        Assert.Equal("1245",output.ToString());
    }

    [Fact]
    public void InsertTest()
    {
        // Given
        string str = "1245";
        ReadOnlySpan<char> input = str.AsSpan();
    
        // When
        ReadOnlySpan<char> output = input.Insert(2,"3");
    
        // Then
        Assert.Equal("12345",output.ToString());
    }
}