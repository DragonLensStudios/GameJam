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

    public void ToggleGameobject(GameObject _gameObject)
    {
        _gameObject.SetActive(!_gameObject.activeSelf);
    }

    public void Update()
    {
        if (GameTimeClockText != null)
        {
            GameTimeClockText.text = "Time Remaining \n" + " Days " + Game.Manage.GameTimeLimit.Day + " Time: " + Game.Manage.GameTimeLimit.TimeString_H_MM;
        }
    }

    public void CallStartGameEvent()
    {
        EventManager.ResetGame();
    }
}
