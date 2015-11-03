using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void D_IncreaseScore();
    public static event D_IncreaseScore IncreaseScoreEvent;

    public delegate void D_ResetGame();
    public static event D_ResetGame ResetGameEvent;

    public delegate void D_MaxFeature();
    public static event D_MaxFeature MaxFeatureEvent;

    public static void IncreaseScore()
    {
        if (IncreaseScoreEvent != null)
        {
            IncreaseScoreEvent();
        }
    }

    public static void ResetGame()
    {
        if (ResetGameEvent != null)
        {
            ResetGameEvent();
        }
    }

    public static void MaxFeature()
    {
        if (MaxFeatureEvent != null)
        {
            MaxFeatureEvent();
        }
    }


}
