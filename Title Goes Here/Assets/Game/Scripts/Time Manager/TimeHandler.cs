using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public Text textTime;
    public Text textTime2;
    public Text dayText;
    public bool timepassed;

    public TimeContainer GameTime = new TimeContainer();
    public TimeContainer ActionTime723 = new TimeContainer(currentmonth:Months.November);


    void Awake()
    {

    }
    // Update is called once per frame
    void Update()
    {
        GameTime.StartTime();
        textTime.text = GameTime.GetTimeString();

        if (GameTime.CheckTime(year: 1, month:1, day: 26))
        {
            textTime2.text = "Year 1 Month 1 Day 26 CHECKED!!";
        }

        if (GameTime.CheckTime(year: 1, month: 1, day: 25))
        {
            textTime2.text = "Year 1 Month 1 Day 25 CHECKED!!";
        }

        if (GameTime.CheckExactTime(10, 0))
        {
            textTime2.text = "Minute 10 Second 0 CHECKED!!";
        }
    }

}
