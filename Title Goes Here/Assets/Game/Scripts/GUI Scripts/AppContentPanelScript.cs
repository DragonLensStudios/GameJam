namespace DLS.Games.TitleGoesHere
{
    using UnityEngine;
    using UnityEngine.UI;
    public class AppContentPanelScript : MonoBehaviour
    {
        public Text DisplayText;
        public Text TimerText;
        public Text FatigueText;

        void Update()
        {
            if (Game.Manage.CurrentGameProject.isWorking)
            {
                TimerText.text = Game.Manage.CurrentGameProject.CurrentFeature.Time.TimeString_H_MM;
                if (DisplayText != null)
                {
                    DisplayText.text = "Working on " + Game.Manage.CurrentGameProject.CurrentFeature.Name; //test content.
                }

            }
            else
            {
                TimerText.text = Game.Manage.Timers.ProcrastinationTime.TimeString_H_MM;
                DisplayText.text = "Procrastinating....."; //test content.
            }

            if (FatigueText != null)
            {
                FatigueText.text = "Fatigue: " + Game.Manage.CurrentGameProject.Fatigue.currentFatigue + "/" + Game.Manage.CurrentGameProject.Fatigue.maxFatigue;
            }
        }
    }

}