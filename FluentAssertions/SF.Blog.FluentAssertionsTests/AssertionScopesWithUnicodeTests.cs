using System;
using System.Globalization;
using System.Linq;
using System.Text;
using FluentAssertions;
using FluentAssertions.Execution;
using NUnit.Framework;

namespace SF.Blog.FluentAssertionsTests;

public class AssertionScopesWithUnicodeTests
{
    [Test]
    public void explore_unicode_with_emoji()
    {
        // https://emojipedia.org/
        var emote = "😂";

        using var scope = new AssertionScope();

        emote.Length.Should().Be( 1 ); // fail
        emote.Should().HaveLength( 1 ); // fail
        
        emote.Length.Should().BePositive(); // pass
        emote.Should().Be( "\ud83d\ude02" ); // pass

        // this is how you handle Unicode
        var combiningCharacters = StringInfo.ParseCombiningCharacters( emote );
        combiningCharacters.Length.Should().Be( 1 ); // pass
    }
    
    [Test]
    public void explore_unicode_with_normalization()
    {
        var aWithCircleOnTop = "\u00c5"; // Å

        using var scope = new AssertionScope();

        aWithCircleOnTop.Should().HaveLength( 1 ); // pass
        aWithCircleOnTop.Should().Be( "Å" ); // pass

        var normalized = aWithCircleOnTop.Normalize(NormalizationForm.FormD);
        
        normalized.Should().Be( aWithCircleOnTop, "the normalized is not represented as the same Unicode" ); // fail
        normalized.Should().Be( "Å", "this is the 00c5 form" ); // fail
        normalized.Should().Be( "\u0041\u030a" ); // pass
        normalized.Should().Be( "Å" , "this is the 0041 + 030a form"); // pass
    }

    [Test]
    public void t()
    {
        
    }
    
    [Test]
    public void ta()
    {
        // https://emojipedia.org/
        var emote = "😂";
        // emote = "🐦‍🔥";
        // emote = "\ud83d\udc26\u200d\ud83d\udd25";
        // emote = "\u00c5";

        using var scope = new AssertionScope();

        emote.Length.Should().Be( 1 ); // fail
        emote.Should().HaveLength( 1 ); // fail
        emote.Length.Should().BePositive(); // pass

        var normalized = emote.Normalize( NormalizationForm.FormKC );
        normalized.Should().HaveLength( 1 );
        normalized.Should().Be( emote );

        var combiningCharacters = StringInfo.ParseCombiningCharacters( emote );
        combiningCharacters.Length.Should().Be( 1 ); // pass

        var nextTextElement = StringInfo.GetNextTextElement( emote );
        nextTextElement.Should().Be( emote );

        var textElementEnumerator = StringInfo.GetTextElementEnumerator( emote );
        textElementEnumerator.Reset();
        textElementEnumerator.MoveNext();
        textElementEnumerator.GetTextElement().Should().Be( emote );
    }
}