using System;

[Serializable]
public class HighscoreElement
{
    public string playerName;
    public float points;

    public HighscoreElement(string name, float points)
    {
        playerName = name;
        this.points = points;
    }

}