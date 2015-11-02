using UnityEngine;
using UnityEngine.UI;

public class StarHandler : MonoBehaviour
{
    public Sprite EmptyStar;
    public Sprite HalfStar;
    public Sprite FullStar;
    public Image[] Stars;


    void OnEnable()
    {
        EventManager.IncreaseScoreEvent += SetStars;
    }

    void OnDisable()
    {
        EventManager.IncreaseScoreEvent -= SetStars;
    }

    public void SetStars()
    {
        if (Stars != null )
        {
            for (int i = 0; i < Stars.Length; i++)
            {
                if (Game.Manage.ScoreSystem.CurrentFeature.Score - i <= 0)
                {
                    Stars[i].sprite = EmptyStar;
                    Debug.Log("Empty Star set.");
                }
                else if (Game.Manage.ScoreSystem.CurrentFeature.Score - i < 1)
                {
                    Stars[i].sprite = HalfStar;
                    Debug.Log("Half Star set.");

                }
                else if (Game.Manage.ScoreSystem.CurrentFeature.Score - i >= 1)
                {
                    Stars[i].sprite = FullStar;
                    Debug.Log("Full Star set.");
                }
                else
                {
                    break;
                }
            }
        }

    }

}

