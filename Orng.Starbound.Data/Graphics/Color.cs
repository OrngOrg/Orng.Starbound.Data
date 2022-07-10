namespace Star;
public class Color
{
    public uint red = 0;
    public uint green = 0;
    public uint blue = 0;
    public uint alpha = 0;

    public void SetRed (uint red) => this.red = red;
    public void SetGreen (uint green) => this.green = green;
    public void SetBlue (uint blue) => this.blue = blue;
    public void SetAlpha (uint alpha) => this.alpha = alpha;

    public float RedF => (float)red / 255f;
    public float GreenF => (float)green / 255f;
    public float BlueF => (float)blue / 255f;
    public float AlphaF => (float)alpha / 255f;

    public void SetRedF(float red) => this.red = (uint)(red * 255f);
    public void SetGreenF(float green) => this.green = (uint)(green * 255f);
    public void SetBlueF(float blue) => this.blue = (uint)(blue * 255f);
    public void SetAlphaF(float alpha) => this.alpha = (uint)(alpha * 255f);

    public bool IsClear() => throw new NotImplementedException();

    public uint ToUint32() => throw new NotImplementedException();
}
