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
        GameEvents.IncreaseScoreEvent += SetStars;
    }

    void OnDisable()
    {
        GameEvents.IncreaseScoreEvent -= SetStars;
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
                }
                else if (Game.Manage.ScoreSystem.CurrentFeature.Score - i < 1)
                {
                    Stars[i].sprite = HalfStar;
                }
                else if (Game.Manage.ScoreSystem.CurrentFeature.Score - i >= 1)
                {
                    Stars[i].sprite = FullStar;
                }
                else
                {
                    break;
                }
            }
        }

    }

}

