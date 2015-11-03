using UnityEngine;

public class GameEvents
{
    public delegate void D_IncreaseScore();
    public static event D_IncreaseScore IncreaseScoreEvent;

    public delegate void D_ResetGame();
    public static event D_ResetGame ResetGameEvent;

    public delegate void D_MaxFeature();
    public static event D_MaxFeature MaxFeatureEvent;

    public delegate void D_ShowMessage(string _message, float _time = 1.5f);
    public static event D_ShowMessage ShowMessageEvent;

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

    public static void ShowMessage(string message, float time = 1.5f)
    {
        if (ShowMessageEvent != null)
        {
             ShowMessageEvent(message,time);
        }
    }


}
