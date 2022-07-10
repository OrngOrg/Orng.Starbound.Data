namespace Star;

public class Plant
{
    public enum RotationType
    {
        DontRotate = 0,
        RotateBranch = 1,
        RotateLeaves = 2,
        RotateCrownBranch = 3,
        RotateCrownLeaves = 4
    }

    public enum PlantPieceKind
    {
        None = 0,
        Stem = 1,
        Foliage = 2
    }
}
