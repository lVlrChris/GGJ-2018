
public enum Diet
{
    Healthy,
    JunkFood
}

public enum Healthy
{
    Banana,
    Apple,
    Grapes
}

public enum Snack
{
    Hotdog,
    Pizza,
    Drumstick
}

public struct ScorePoints
{
    public const float dietfood = 5;
    public const  float wrongFood = -5;
    public const  float shotPenalty = -2.5f;
    public const  float accuracyBonus = 25;
}