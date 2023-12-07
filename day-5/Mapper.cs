namespace day_5;

public class Mapper
{
    private readonly Map _seedToSoilMap;
    private readonly Map _soilToFertilizerMap;
    private readonly Map _fertilizerToWaterMap;
    private readonly Map _waterToLightMap;
    private readonly Map _lightToTemperatureMap;
    private readonly Map _temperatureToHumidityMap;
    private readonly Map _humidityToLocationMap;

    public Mapper(
        Map seedToSoilMap,
        Map soilToFertilizerMap,
        Map fertilizerToWaterMap,
        Map waterToLightMap,
        Map lightToTemperatureMap,
        Map temperatureToHumidityMap,
        Map humidityToLocationMap)
    {
        _seedToSoilMap = seedToSoilMap;
        _soilToFertilizerMap = soilToFertilizerMap;
        _fertilizerToWaterMap = fertilizerToWaterMap;
        _waterToLightMap = waterToLightMap;
        _lightToTemperatureMap = lightToTemperatureMap;
        _temperatureToHumidityMap = temperatureToHumidityMap;
        _humidityToLocationMap = humidityToLocationMap;
    }

    public long MapToLocation(long seed) =>
        _humidityToLocationMap.MapFromSourceToDestination(
            _temperatureToHumidityMap.MapFromSourceToDestination(
                _lightToTemperatureMap.MapFromSourceToDestination(
                    _waterToLightMap.MapFromSourceToDestination(
                        _fertilizerToWaterMap.MapFromSourceToDestination(
                            _soilToFertilizerMap.MapFromSourceToDestination(
                                _seedToSoilMap.MapFromSourceToDestination(seed)))))));

    public long MapToSeed(long location) =>
        _seedToSoilMap.MapFromDestinationToSource(
            _soilToFertilizerMap.MapFromDestinationToSource(
                _fertilizerToWaterMap.MapFromDestinationToSource(
                    _waterToLightMap.MapFromDestinationToSource(
                        _lightToTemperatureMap.MapFromDestinationToSource(
                            _temperatureToHumidityMap.MapFromDestinationToSource(
                                _humidityToLocationMap.MapFromDestinationToSource(location)))))));
}