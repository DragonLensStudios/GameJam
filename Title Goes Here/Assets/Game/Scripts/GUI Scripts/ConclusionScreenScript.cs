using UnityEngine;
using UnityEngine.UI;

public class ConclusionScreenScript : MonoBehaviour
{
    public Text GameTitle;

    void OnEnable()
    {
        GameTitle.text = Game.Manage.GameName;
    }

    public void ReturnToTitle()
    {
        Game.Manage.UI.MainMenuPanel.SetActive(true);
        Destroy(gameObject);
    }
}
