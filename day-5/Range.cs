namespace day_5;

public record Range(
    long SourceStart,
    long DestinationStart,
    long SourceToDestinationDifference,
    long Length)
{
    public bool SourceFits(long source) => SourceStart <= source && source <= SourceStart + Length - 1;
    public bool DestinationFits(long destination) => DestinationStart <= destination && destination <= DestinationStart + Length - 1;

    public long MapFromSourceToDestination(long source) => source + SourceToDestinationDifference;
    public long MapFromDestinationToSource(long destination) => destination - SourceToDestinationDifference;
}