namespace DLS.Games.TitleGoesHere
{
    using UnityEngine;
    public class AppOpenPanel : MonoBehaviour
    {
        public GameObject TopBarPanel;
        public GameObject ContentPanel;
        public TopAppPanelScript top_panel_script;
        public AppContentPanelScript content_panel_script;

        void Awake()
        {
            if (TopBarPanel != null)
            {
                top_panel_script = TopBarPanel.GetComponent<TopAppPanelScript>();
            }
            if (ContentPanel != null)
            {
                content_panel_script = ContentPanel.GetComponent<AppContentPanelScript>();
            }
        }

        public void ExitButton()
        {
            Game.Manage.CloseApp();
        }
    }
}

