using UnityEngine;

public static class BallManager
{
    public static int BallId
    {
        get
        {
            return PlayerPrefs.GetInt("ballSpriteName", 1);
        }

        set
        {
            PlayerPrefs.SetInt("ballSpriteName", value);
        }
    }
}
