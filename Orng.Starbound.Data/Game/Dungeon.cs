namespace Star;

public class Dungeon
{
    public enum Phase
    {
        ClearPhase = 0,
        WallPhase = 1,
        ModsPhase = 2,
        ObjectPhase = 3,
        BiomeTreesPhase = 4,
        BiomeItemsPhase = 5,
        WirePhase = 6,
        ItemPhase = 7,
        NpcPhase = 8,
        DungeonIdPhase = 9
    }

    public enum Direction
    {
        Left = 0,
        Right = 1,
        Up = 2,
        Down = 3,
        Unknown = 4,
        Any = 5
    }

    public enum TileFlip
    {
        Horizontal = -2147483648,
        Vertical = 1073741824,
        Diagonal = 536870912,
        AllBits = -536870912
    }

    public enum ObjectKind
    {
        Tile = 0,
        Rectangle = 1,
        Ellipse = 2,
        Polygon = 3,
        Polyline = 4,
        Stagehand = 5
    }
}
