namespace day_5;

public class Map
{
    private readonly IReadOnlyCollection<Range> _ranges;

    public Map(IReadOnlyCollection<Range> ranges)
    {
        _ranges = ranges;
    }

    public long MapFromSourceToDestination(long source)
    {
        var range = _ranges.FirstOrDefault(r => r.SourceFits(source));

        return range?.MapFromSourceToDestination(source) ?? source;
    }
    
    public long MapFromDestinationToSource(long destination)
    {
        var range = _ranges.FirstOrDefault(r => r.DestinationFits(destination));

        return range?.MapFromDestinationToSource(destination) ?? destination;
    }
}