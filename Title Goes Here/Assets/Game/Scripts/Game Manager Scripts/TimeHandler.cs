using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public Text textTime;
    public Text textTime2;
    public Text dayText;

    public bool timepassed;

    public TimeContainer GameTime;
    public TimeContainer ActionTime;

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        GameTime.StartTime();
        ActionTime.StartTime();


//        if (GameTime.CheckFullTime(hour:2) && GameTime.CheckSecond(0))
//        {
//            Debug.Log("Called!!");
//
//        }

//        if (GameTime.CheckSecond(10) && GameTime.secondCheckBool == false)
//        {
//            Debug.Log((int)GameTime.Second + " Secs Passed");
//            GameTime.secondCheckBool = true;
//        }

//        if (GameTime.CheckExactFullTime(hour:3))
//        {
//            Debug.Log("Called!!");
//        }

//        else
//        {
//            Debug.Log("This is false!");
//            GameTime.ClearAllChecks();
//        }
//        if (GameTime.CheckFullTime(day: 1, hour: 5,minute: 30,second:0))
//        {
//            Debug.Log("testing new full time");
//            GameTime.ClearAllChecks();
//
//        }

//        if (GameTime.secondCheckBool == false && GameTime.CheckSecond(3))
//        {
//            Debug.Log("10 Sec Clocked!");
//            GameTime.secondCheckBool = true;
//        }

//        if (GameTime.CheckFullTime(minute: 5, second: 30))
//        {
//            Debug.Log("This worked!");
//        }


        //        if (GameTime.CheckFullTime(hour:2))
        //        {
        //            if (ActionTime.CheckMinute(5) && ActionTime.CheckSecond(0))
        //            {
        //                Debug.Log("So True");
        //            }
        //
        //        }
        //        else
        //        {
        //            ActionTime.StartTime();
        //        }
        //    }

    }
}
