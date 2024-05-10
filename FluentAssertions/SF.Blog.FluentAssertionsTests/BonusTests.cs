using System;
using FluentAssertions;
using NUnit.Framework;

namespace SF.Blog.FluentAssertionsTests;

public class BonusTests
{
    [Test]
    public void pi_should_be_greater_than_3()
    {
        Math.PI.Should().BeGreaterThan( 3D );
    }    
    
    [Test]
    public void abs_should_not_throw()
    {
        var abs = () => Math.Abs( 10D );
        abs.Should().NotThrow();
    }
}