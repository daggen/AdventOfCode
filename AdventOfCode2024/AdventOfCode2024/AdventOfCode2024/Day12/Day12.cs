namespace AdventOfCode2024.Day12;

public class Day12
{

    public string GetSum1()
    {
        var matrix = File.ReadLines("../../../Day12/Input.txt")
            .Select((line, row) => line.Select((c, column) => new Plant(c, row, column)))
            .SelectMany(x => x)
            .ToList();

        var regions = new List<Region>();

        foreach (var plant in matrix)
        {
            var region = regions.FirstOrDefault(r => r.ShouldContain(plant));
            if (region == null)
            {
                region = new Region(plant.Type);
                regions.Add(region);
            }

            region.Add(plant);
        }

        var mergedRegions = new List<Region>();
        foreach (var region in regions)
        {
            var mergedRegion = mergedRegions.FirstOrDefault(r => r.AreNeighbors(region));
            if (mergedRegion == null)
            {
                mergedRegions.Add(region);
            }
            else
            {
                mergedRegion.MergeWith(region);
            }
        }

        return mergedRegions.Sum(r => r.Fence).ToString();
    }

    private class Plant(
        char type, int row, int column)
    {
        public bool IsNeighbor(Plant plant) => Math.Abs(plant.Row - Row) + Math.Abs(plant.Column - Column) == 1;

        public int Row => row;
        public int Column => column;
        public char Type => type;
    }
    private class Region(char type)
    {
        private List<Plant> plants = new();

        public bool ShouldContain(Plant plant) => plant.Type == type && plants.Any(p => p.IsNeighbor(plant));

        public char Type => type;

        public long Fence => plants.Select(p => 4 - GetNumberOfNeighbors(p))
            .Sum() * plants.Count;

        private int GetNumberOfNeighbors(Plant plant)
        {
            return plants.Count(p => p.IsNeighbor(plant));
        }

        public void Add(Plant plant)
        {
            plants.Add(plant);
        }

        public bool AreNeighbors(Region region)
        {
            if (region.Type != type)
            {
                return false;
            }

            return plants.Any(p => region.plants.Any(p.IsNeighbor));
        }

        public void MergeWith(Region region)
        {
            plants.AddRange(region.plants);
        }
    }
}
