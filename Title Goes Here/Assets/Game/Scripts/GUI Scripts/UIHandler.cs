using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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
            GameTimeClockText.text = "Time Remaining \n" + " Days " + Game.Manage.GameTimeLimit.Day + " Time: " + Game.Manage.GameTimeLimit.TimeString_H_MM;
        }

        if(FadeMessage && (int)canvas.alpha == 0)
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
        Game.Manage.GameName = GameNameInput.text;
    }

    public void ShowMessage(string _message, float _time)
    {
        if (_time != 1.5f)
        {
            MessageWaitTime = _time;
        }
        MessageBoxText.text = _message;
        StartCoroutine(IE_ShowMessageWait(_time));
    }

    public IEnumerator IE_ShowMessageWait(float _time)
    {
        FadeMessage = true;
        yield return new WaitForSeconds(_time);
        FadeMessage = false;
    }
}
