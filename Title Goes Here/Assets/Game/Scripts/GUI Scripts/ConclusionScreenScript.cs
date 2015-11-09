namespace DLS.Games.TitleGoesHere
{
    using UnityEngine;
    using UnityEngine.UI;

    public class ConclusionScreenScript : MonoBehaviour
    {
        public Text GameTitle;

        void OnEnable()
        {
            GameTitle.text = Game.Manage.CurrentGameProject.Name;
        }

        public void ReturnToTitle()
        {
            Game.Manage.UI.MainMenuPanel.SetActive(true);
            Destroy(gameObject);
        }
    }
}

