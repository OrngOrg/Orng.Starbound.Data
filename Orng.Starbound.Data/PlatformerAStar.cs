namespace Star;

public class PlatformerAStar
{
    public enum Action
    {
        Walk = 0,
        Jump = 1,
        Arc = 2,
        Drop = 3,
        Swim = 4,
        Fly = 5,
        Land = 6
    }

    public class PathFinder
    {
        public enum BoundBoxKind
        {
            Full = 0,
            Drop = 1,
            Stand = 2
        }
    }

}
