namespace DLS.Games.TitleGoesHere
{
    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    /// <summary>
    /// This class handles all UI calls and stores UI elements to be used and referenced.
    /// </summary>
    public class UIHandler : MonoBehaviour
    {
        public InputField GameNameInput;
        public GameObject CurrentAppPanel;
        public GameObject MainMenuPanel;
        public GameObject DoorOSMainPanel;
        public GameObject DoorAppsPanel;
        public GameObject ConclusionScreen;
        public Text GameTimeClockText;
        public Text FatigueText;
        public GameObject MessageBoxGameObject;
        public Text MessageBoxText;

        public GameObject ConclusionPanelPrefab;

        private float MessageWaitTime = 1.5f;
        private bool FadeMessage;


        public void OnEnable()
        {
            GameEvents.ShowMessageEvent += ShowMessage;
        }

        public void OnDisable()
        {
            GameEvents.ShowMessageEvent -= ShowMessage;
        }

        public void ToggleGameobject(GameObject _gameObject)
        {
            _gameObject.SetActive(!_gameObject.activeSelf);
        }

        public void Update()
        {
            CanvasGroup canvas = MessageBoxGameObject.GetComponent<CanvasGroup>();

            if (GameTimeClockText != null)
            {
                GameTimeClockText.text = "Time Remaining \n" + " Days " + Game.Manage.Timers.GameTimeLimit.Day + " Time: " + Game.Manage.Timers.GameTimeLimit.TimeString_H_MM;
            }

            if (FadeMessage && (int)canvas.alpha == 0)
            {
                canvas.alpha = canvas.alpha += Time.deltaTime * MessageWaitTime;
            }

            if (FadeMessage == false && canvas.alpha > 0)
            {
                canvas.alpha = canvas.alpha -= Time.deltaTime * MessageWaitTime;
            }
        }

        public void CallStartGameEvent()
        {
            GameEvents.ResetGame();
            Game.Manage.CurrentGameProject.Name = GameNameInput.text;
        }

        public void ShowMessage(string _message, float _time)
        {
            MessageWaitTime = _time;
            MessageBoxText.text = _message;
            StartCoroutine(IE_ShowMessageWait(_time));
        }

        public IEnumerator IE_ShowMessageWait(float _time)
        {
            FadeMessage = true;
            yield return new WaitForSeconds(_time);
            FadeMessage = false;
        }

        public void ShowRewardAvert()
        {
            UnityAds.ShowRewardedAdvertisement();
        }

        public void SetGameState(int gamestateindex)
        {
            Game.Manage.CurrentGameState = (GameState)gamestateindex;
        }

        public void SetFeature(int featureindex)
        {
            Game.Manage.CurrentGameProject.Feature = (FeatureType)featureindex;
        }
    }

}
