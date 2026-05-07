using UnityEngine;

public enum PostColor
{
    Red,
    Blue,
    Green
}

public class Post
{
    public PostColor color;
    public float[] features;

    public Post(PostColor c)
    {
        color = c;
        features = ConvertColorToFeatures(c);
    }

    private float[] ConvertColorToFeatures(PostColor c)
    {
        switch (c)
        {
            case PostColor.Red:
                return new float[] { 1f, 0f, 0f };

            case PostColor.Blue:
                return new float[] { 0f, 1f, 0f };

            case PostColor.Green:
                return new float[] { 0f, 0f, 1f };

            default:
                return new float[] { 0f, 0f, 0f };
        }
    }
}
