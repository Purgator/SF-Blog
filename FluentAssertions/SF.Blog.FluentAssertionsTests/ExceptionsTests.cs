using System;
using FluentAssertions;
using NUnit.Framework;

namespace SF.Blog.FluentAssertionsTests;

public class ExceptionsTests
{
    [Test]
    public void exception_thrower_should_throw_aggregate_exception_and_inner_argument_exception()
    {
        var sut = new SomeService();

        sut.Invoking( s => s.ExceptionThrower() )
           .Should().Throw<AggregateException>()
           .WithMessage( "*AggregateException message.*" )
           .WithInnerException<ArgumentException>()
           .WithMessage( "ArgumentException message." );
    }

    [Test]
    public void exception_thrower_should_throw_aggregate_exception_and_inner_argument_exception_AAA_syntax()
    {
        var sut = new SomeService();

        var act = () => sut.ExceptionThrower();
        
        act.Should().Throw<Exception>();
    }
}

public class SomeService
{
    public void ExceptionThrower()
    {
        throw new AggregateException
        (
            "AggregateException message.",
            new ArgumentException( "ArgumentException message." )
        );
    }
}