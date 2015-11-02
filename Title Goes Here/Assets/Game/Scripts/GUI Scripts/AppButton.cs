using UnityEngine;
public class AppButton : MonoBehaviour
{
    public string AppName;
    public FeatureType AppFeature = FeatureType.NONE;
    public GameState GameState = GameState.NONE;
    public bool AppHasStars = false;
    public GameObject AppPanelPrefab;
    private AppOpenPanel _appPanel;
    private GameObject AppPanelObject;
    void Awake()
    {
        gameObject.name = AppName + " Button";
    }

    public void OpenPanel()
    {
        if (AppPanelPrefab != null && AppPanelObject == null)
        {
            AppPanelObject = Instantiate(AppPanelPrefab);
            _appPanel = AppPanelObject.GetComponent<AppOpenPanel>();
            AppPanelObject.transform.SetParent(Game.Manage.UI.DoorOSMainPanel.transform, false);
            AppPanelObject.SetActive(false);
        }
        if (AppPanelObject != null)
        {
            Game.Manage.UI.CurrentAppPanel = AppPanelObject;
            AppPanelObject.name = AppName + " Panel";
            _appPanel.top_panel_script.TitleText.text = AppName;
            if (AppHasStars)
            {
                _appPanel.top_panel_script.StarHandlerObject.SetActive(true);
            }
            else
            {
                _appPanel.top_panel_script.StarHandlerObject.SetActive(false);
            }
            AppPanelObject.SetActive(!AppPanelObject.activeSelf);
        }

        if (GameState != GameState.NONE)
        {
            Game.Manage.CurrentGameState = GameState;
        }

        if (AppFeature == FeatureType.NONE)
        {
            Game.Manage.SetProcrastinating();
        }
        else
        {
            Game.Manage.SetWorking();
        }
        Game.Manage.ScoreSystem.Feature = AppFeature;

    }
}
