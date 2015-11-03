using UnityEngine;
using UnityEngine.UI;

public class AppContentPanelScript : MonoBehaviour
{
    public Text DisplayText;
    public Text TimerText;
    public Text FatigueText;

    void Update()
    {
        if (Game.Manage.ScoreSystem.isWorking)
        {
            TimerText.text = Game.Manage.ScoreSystem.CurrentFeature.Time.TimeString_H_MM;
            if (DisplayText != null)
            {
                DisplayText.text = "Working on " + Game.Manage.ScoreSystem.CurrentFeature.Name; //test content.
            }

        }
        else
        {
            TimerText.text = Game.Manage.ProcrastinationTime.TimeString_H_MM;
            DisplayText.text = "Procrastinating....."; //test content.
        }

        if (FatigueText != null)
        {
            FatigueText.text = "Fatigue: " + Game.Manage.ScoreSystem.Fatigue.currentFatigue + "/" + Game.Manage.ScoreSystem.Fatigue.maxFatigue;
        }
    }
}
