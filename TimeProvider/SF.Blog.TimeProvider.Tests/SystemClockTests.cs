using FluentAssertions;

namespace Blog;

public sealed class SystemClockTests
{
    [Test]
    public void a_stock_date_cannot_be_tested_out()
    {
        ISystemClock clock = new SystemClock();
        var document = $"I have no idea what time it is {clock.UtcNow}";
    }

    [Test]
    public void the_fake_implementation_can_be_controlled_to_return_specific_value()
    {
        ISystemClock clock = new FakeClock();
        var document = $"I have no idea what time it is {clock.UtcNow:yy/MM/dd}";
        document.Should().Be( $"I have no idea what time it is 24/05/10" );
    }

    public sealed class FakeClock : ISystemClock
    {
        public DateTime UtcNow => DateTime.Parse( "2024-05-10" );
    }
}

public interface ISystemClock
{
    DateTime UtcNow { get; }
}

public sealed class SystemClock : ISystemClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
