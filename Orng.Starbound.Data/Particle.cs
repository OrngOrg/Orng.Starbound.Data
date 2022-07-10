namespace Star;

public class Particle
{
    public enum Layer
    {
        Back = 0,
        Middle = 1,
        Front = 2
    }

    public enum Type
    {
        Variance = 0,
        Ember = 1,
        Textured = 2,
        Animated = 3,
        Streak = 4,
        Text = 5
    }

    public enum DestructionAction
    {
        None = 0,
        Image = 1,
        Fade = 2,
        Shrink = 3
    }

}
