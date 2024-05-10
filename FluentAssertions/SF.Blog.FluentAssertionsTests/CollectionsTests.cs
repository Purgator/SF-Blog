using FluentAssertions;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace SF.Blog.FluentAssertionsTests;

public class CollectionsTests
{
    [Test]
    public void a_supermarket_should_have_pasta()
    {
        var supermarket = new[] { "pasta", "potatoes", "water" };
        var expected = new[] { "pasta", "water" };

        supermarket.Should().BeEquivalentTo( expected );
        supermarket.Should().AllBeOfType<string>();
        
        supermarket.Should().Contain( "pasta" );

        supermarket.Should().NotBeEmpty();
        supermarket.Should().AllBeOfType<string>();
        supermarket.Should().Contain( expected );
        supermarket.Should().BeEquivalentTo( "potatoes", "pasta", "water" );
        supermarket.Should().HaveCountGreaterThan
            ( 2 ); // when it has 2 or less elements, it's a market, not supermarket.
    }

    [Test]
    public void ids_should_only_have_unique_items()
    {
        var ids = new[] { 2, 3, 4, 5, 6, 7, 8 };

        ids.Should().OnlyHaveUniqueItems();
        ids.Should().BeInAscendingOrder(); // just for fun
    }

    [Test]
    public void differences_with_classic_output()
    {
        var choucroute = "this is wrong";
        var expected = "this is right";

        choucroute.Should().Be( expected );
        // Assert.AreEqual(expected, result );
    }

    private record Coordinate( int X, int Y );

    [Test]
    public void collections_are_well_handled()
    {
        var resultCoordinates = new Coordinate[]
        {
            new( 0, 0 ),
            new( 0, 1 ),
            new( 0, 2 ),
        };

        var expectedCoordinates = new Coordinate[]
        {
            new( 0, 0 ),
            new( 1, 0 ),
        };

        resultCoordinates.Should().BeEquivalentTo( expectedCoordinates );
    }
}