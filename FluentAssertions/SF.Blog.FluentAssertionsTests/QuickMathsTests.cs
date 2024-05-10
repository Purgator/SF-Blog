using FluentAssertions;
using NUnit.Framework;

namespace SF.Blog.FluentAssertionsTests;

public class QuickMathsTests
{
    [Test]
    public void two_plus_two_is_four_minus_one_that_three_quick_maths()
    {
        ( 2 + 2 ).Should().Be( 4 );
        ( 4 - 1 ).Should().Be( 3 );
    }
}
