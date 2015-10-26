//using System;

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TimeHandler : MonoBehaviour
{
    public Text textTime;
    public Text textTime2;
    public Text dayText;

    public bool timepassed;

    public TimeContainer GameTime = new TimeContainer();
    public TimeContainer ActionTime = new TimeContainer();

    // Use this for initialization
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        GameTime.ValidateTime();
        if (GameTime.CheckSecond(5))
        {
            Debug.Log("testing");
        }
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
        //            ActionTime.ValidateTime();
        //        }
        //    }

    }
}
